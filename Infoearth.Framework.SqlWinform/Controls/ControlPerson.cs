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
    public partial class ControlPerson : UserControl
    {
        private PersonManager _personManager = new PersonManager();

        public ControlPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPerson formPerson = new FormPerson();
            if (DialogResult.OK == formPerson.ShowDialog())
            {
                IniDataGrid();
            }
        }

        private void ControlPerson_Load(object sender, EventArgs e)
        {
            dataGridView1.BindDb<Person>(IniDataGrid);
            IniDataGrid();
        }

        private void IniDataGrid()
        {
            string keyword = textBox1.Text;
            var datas = _personManager.CurrentDb.AsQueryable().WhereIF(!string.IsNullOrWhiteSpace(keyword), t => t.name.Contains(keyword)).ToList();           
            dataGridView1.DataSource = datas;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //删除
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                int id = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
                bool success = _personManager.CurrentDb.DeleteById(id);
                if (success)
                    IniDataGrid();
            }
            else if (e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                var datas = dataGridView1.DataSource as List<Person>;

                var current = datas[e.RowIndex];

                FormPerson formPerson = new FormPerson(current);
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
                List<Person> persons = ExcelReader.GetExcelContent<Person>(openFileDialog.FileName, sheets[0]);
                _personManager.Insert(persons);
                MessageBox.Show($"成功导入{persons.Count}条信息");
                IniDataGrid();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sheet文件|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var datas = dataGridView1.DataSource as List<Person>;
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
                File.Copy(Path.Combine(Application.StartupPath, "ExcelFile", "人员信息录入.xlsx"), saveFileDialog.FileName);
                MessageBox.Show("下载成功");
            }
        }
    }
}
