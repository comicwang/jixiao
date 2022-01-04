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
    public partial class ControlProjectSummary : UserControl
    {
        private ProjectManager _projectManager = new ProjectManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private PersonManager _personManager = new PersonManager();

        public ControlProjectSummary()
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
            dataGridView1.BindDb<ProjectSummary>(null,false,false,true);
            IniGrid();
        }

        private void IniGrid()
        {
            string projectName = textBox1.Text;
            string group = comboGroup.Text;
            string type = comboAlloteState.Text;
            var projects = _projectManager.CurrentDb.AsQueryable().WhereIF(!string.IsNullOrWhiteSpace(projectName), t => t.name.Contains(projectName)).WhereIF(!string.IsNullOrWhiteSpace(group), t => t.group == group).WhereIF(type == "未开始分配", t => t.allotMoney == 0).WhereIF(type == "未分配完成", t => t.allotMoney > 0 && t.allotMoney != t.memony).WhereIF(type == "已分配完成", t => t.memony == t.allotMoney).ToList();

            var p2pInfos = _p2pManager.CurrentDb.GetList();
            var personInfos = _personManager.CurrentDb.GetList();
            foreach (var item in p2pInfos)
            {
                item.person = personInfos.Where(t => t.id == item.peid).FirstOrDefault();               
            }
           

            List<ProjectSummary> result = new List<ProjectSummary>();
            foreach (var item in projects)
            {
                ProjectSummary projectSummary = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectSummary>(Newtonsoft.Json.JsonConvert.SerializeObject(item));

                var p2pInfo = p2pInfos.Where(t => t.prid == item.id);
                projectSummary.mainPersons = string.Join(",", p2pInfo.Where(t=>t.allot==Entity.allotEnum.主要).Select(s => s.personName));
                projectSummary.mainAllotedInfo = string.Join("\r\n", p2pInfo.Where(t => t.allot == Entity.allotEnum.主要).Select(s => s.personName + ":" + s.money.ToMoney()));
                projectSummary.otherPersonCount = p2pInfo.Count(t => t.allot == Entity.allotEnum.普惠);
                projectSummary.otherAllotedInfo = string.Join("\r\n", p2pInfo.Where(t => t.allot == Entity.allotEnum.普惠).Select(s => s.personName + ":" + s.money.ToMoney()));

                result.Add(projectSummary);
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
                var datas = dataGridView1.DataSource as List<ProjectSummary>;
                datas.SaveDataToExcelFile(saveFileDialog.FileName);

                MessageBox.Show("导出成功");
            }
        }
    }
}
