using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infoearth.Framework.SqlWinform.Dto;
using Infoearth.Framework.SqlWinform.Entity;
using Infoearth.Framework.SqlWinform.extention;
using Infoearth.Framework.SqlWinform.Services;

namespace Infoearth.Framework.SqlWinform.Controls
{
    public partial class ControlPersonSummary : UserControl
    {
        private ProjectManager _projectManager = new ProjectManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private PersonManager _personManager = new PersonManager();
        private Money2PersonManager _p2mManager = new Money2PersonManager();

        public ControlPersonSummary()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IniGrid();
        }

        private void ControlProjectSummary_Load(object sender, EventArgs e)
        {
            //绑定所有下拉框
            foreach (var item in this.groupBox1.Controls)
            {
                if (item.GetType() == typeof(ComboBox))
                {
                    ComboBox comboBox = item as ComboBox;
                    comboBox.BindDb();
                    comboBox.BindInput();
                }
            }
            comboRoom.Text = string.Empty;
            comboPosition.Text = string.Empty;
            dataGridView1.BindDb<PersonSummary>(null, false, false, true);
            IniGrid();
        }

        private void IniGrid()
        {
            string name = textBox1.Text;
            string room = comboRoom.Text;
            string positon = comboPosition.Text;
            var persons = _personManager.CurrentDb.AsQueryable().WhereIF(!string.IsNullOrWhiteSpace(name), t => t.name.Contains(name)).WhereIF(!string.IsNullOrWhiteSpace(room), t => t.room == room).WhereIF(!string.IsNullOrWhiteSpace(positon), t => t.position == positon).ToList();

            var p2pInfos = _p2pManager.CurrentDb.GetList();
            var projects = _projectManager.CurrentDb.AsQueryable().Select(t => new Project() { id = t.id, name = t.name }).ToList();
            var p2mInfos = _p2mManager.CurrentDb.GetList();
            foreach (var item in p2pInfos)
            {
                item.project = projects.Where(t => t.id == item.prid).FirstOrDefault();               
            }
           

            List<PersonSummary> result = new List<PersonSummary>();
            foreach (var item in persons)
            {
                PersonSummary personSummary = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonSummary>(Newtonsoft.Json.JsonConvert.SerializeObject(item));

                var p2pInfo = p2pInfos.Where(t => t.peid == item.id);
                personSummary.AllotedTimes = p2pInfo.Count();
                personSummary.AllotedMoney = p2pInfo.Sum(t => t.money);
                personSummary.AllotedInfo = string.Join("\r\n", p2pInfo.Select(t => t.project.name + "(" + t.allot + "):" + t.money.ToMoney() ));

                var p2mInfo = p2mInfos.Where(t => t.peid == item.id);
                personSummary.CashedMoney = p2mInfo.Sum(t => t.cashMoney);
                personSummary.CashedTimes = p2mInfo.Count();
                personSummary.CashedInfo = string.Join("\r\n", p2mInfo.Select(t => t.cashGroup + ":" + t.cashMoney.ToMoney()));

                result.Add(personSummary);
            }

            int rowIndex = 1;
            result.ForEach(t => { t.Grid_Num = rowIndex; rowIndex++; });
            dataGridView1.DataSource = result;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sheet文件|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var datas = dataGridView1.DataSource as List<PersonSummary>;
                datas.SaveDataToExcelFile(saveFileDialog.FileName);

                MessageBox.Show("导出成功");
            }
        }
    }
}
