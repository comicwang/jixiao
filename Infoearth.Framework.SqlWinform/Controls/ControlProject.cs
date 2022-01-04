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
    public partial class ControlProject : UserControl
    {
        private ProjectManager _ProjectManager = new ProjectManager();

        public ControlProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProject formProject = new FormProject();
            if (DialogResult.OK == formProject.ShowDialog())
            {
                IniDataGrid();
            }
        }

        private void ControlProject_Load(object sender, EventArgs e)
        {
            dataGridView1.BindDb<Project>(IniDataGrid, false, false, true);
            IniDataGrid();
        }

        private void IniDataGrid()
        {
            string keyword = textBox1.Text;
            var datas = _ProjectManager.CurrentDb.AsQueryable().WhereIF(!string.IsNullOrWhiteSpace(keyword), t => t.name.Contains(keyword)).ToList();
            int rowIndex = 1;
            datas.ForEach(t => { t.Grid_Num = rowIndex; rowIndex++; });
            dataGridView1.DataSource = datas;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //删除
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                int id = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
                bool success = _ProjectManager.CurrentDb.DeleteById(id);
                if (success)
                    IniDataGrid();
            }
            else if (e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                var datas = dataGridView1.DataSource as List<Project>;

                var current = datas[e.RowIndex];

                FormProject formProject = new FormProject(current);
                if (formProject.ShowDialog() == DialogResult.OK)
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
            //bussnessMocker.MockProject(55);
            //IniDataGrid();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "2007excel|*.xlsx|sheet文件|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sheets = ExcelReader.GetExcelSheetName(openFileDialog.FileName);
                List<Project> persons = ExcelReader.GetExcelContent<Project>(openFileDialog.FileName, sheets[0]);
                _ProjectManager.Insert(persons);
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
                var datas = dataGridView1.DataSource as List<Project>;
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
                File.Copy(Path.Combine(Application.StartupPath, "ExcelFile", "项目信息录入.xlsx"), saveFileDialog.FileName);
                MessageBox.Show("下载成功");
            }
        }
    }
}
