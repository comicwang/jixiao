using Infoearth.Framework.SqlWinform.Entity;
using Infoearth.Framework.SqlWinform.Forms;
using Infoearth.Framework.SqlWinform.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infoearth.Framework.SqlWinform.extention;
using Infoearth.Framework.SqlWinform.Mock;
using System.IO;

namespace Infoearth.Framework.SqlWinform.Controls
{
    public partial class ControlPerson2Money : UserControl
    {
        private Money2PersonManager _m2pManager = new Money2PersonManager();
        private PersonManager _personManager = new PersonManager();

        public ControlPerson2Money()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMoney2Person formPerson = new FormMoney2Person();
            if (DialogResult.OK == formPerson.ShowDialog())
            {
                IniDataGrid();
            }
        }

        private void ControlPerson_Load(object sender, EventArgs e)
        {
            //绑定所有下拉框
            foreach (var item in this.groupBox1.Controls)
            {
                if (item.GetType() == typeof(ComboBox))
                {
                    ComboBox comboBox = item as ComboBox;
                    comboBox.BindDb();
                }
            }
            dataGridView1.BindDb<Money2Person>(IniDataGrid);
            IniDataGrid();
        }

        private void IniDataGrid()
        {
            string keyword = textBox1.Text;
            List<int> ids = new List<int>();
            if (!string.IsNullOrWhiteSpace(keyword))
                ids = _personManager.CurrentDb.AsQueryable().Where(t => t.name.Contains(keyword)).Select(t => t.id).ToList();
            var datas = _m2pManager.CurrentDb.AsQueryable().WhereIF(!string.IsNullOrWhiteSpace(keyword), t => ids.Contains(t.peid)).WhereIF(!string.IsNullOrWhiteSpace(comboCashGroup.Text), t => t.cashGroup == comboCashGroup.Text).Mapper(t => t.person, t => t.peid).ToList();

            dataGridView1.DataSource = datas;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //删除
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                int id = int.Parse(dataGridView1["idDataGridViewTextBoxColumn", e.RowIndex].Value.ToString());
                bool success = _m2pManager.CurrentDb.DeleteById(id);
                if (success)
                    IniDataGrid();
            }
            else if (e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                var datas = dataGridView1.DataSource as List<Money2Person>;

                var current = datas[e.RowIndex];

                FormMoney2Person formPerson = new FormMoney2Person(current);
                if (formPerson.ShowDialog() == DialogResult.OK)
                    IniDataGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IniDataGrid();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //BussnessMocker bussnessMocker = new BussnessMocker();
            //bussnessMocker.MockPersons(300);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "2007excel|*.xlsx|sheet文件|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sheets = ExcelReader.GetExcelSheetName(openFileDialog.FileName);
                List<Money2Person> persons = ExcelReader.GetExcelContent<Money2Person>(openFileDialog.FileName, sheets[0]);
                if (persons != null && persons.Count > 0)
                {
                    var selPerson = _personManager.CurrentDb.AsQueryable().In(t => t.name, persons.Select(s => s.cashName.Trim()).ToArray()).Select(t => new Person() { id = t.id, name = t.name }).ToList();
                    foreach (var item in persons)
                    {
                        Person temp = selPerson.Where(t => t.name == item.cashName).FirstOrDefault();
                        if (temp != null)
                            item.peid = temp.id;
                    }
                    _m2pManager.Insert(persons);
                    MessageBox.Show($"成功导入{persons.Count}条信息");
                    IniDataGrid();
                }
                else
                {
                    MessageBox.Show("导入的数据为空");
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sheet文件|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var datas = dataGridView1.DataSource as List<Money2Person>;
                datas.SaveDataToExcelFile(saveFileDialog.FileName);

                MessageBox.Show("导出成功");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sheet文件|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Path.Combine(Application.StartupPath, "ExcelFile", "绩效兑现录入.xlsx"), saveFileDialog.FileName);
                MessageBox.Show("下载成功");
            }
        }
    }
}
