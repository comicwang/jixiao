using Infoearth.Framework.SqlWinform.Entity;
using Infoearth.Framework.SqlWinform.extention;
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

namespace Infoearth.Framework.SqlWinform.Forms
{
    public partial class FormPersonSel : Form
    {
        private PersonManager _personManager = new PersonManager();
        public FormPersonSel()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormPerson formPerson = new FormPerson();
            if (DialogResult.OK == formPerson.ShowDialog())
            {
                IniDataGrid();
            }
        }

        private void FormPersonSel_Load(object sender, EventArgs e)
        {
            dataGridView1.BindDb<Person>(IniDataGrid, true);
            IniDataGrid();
        }

        private void IniDataGrid()
        {
            string keyword = textBox1.Text;
            var datas = _personManager.CurrentDb.AsQueryable().WhereIF(!string.IsNullOrWhiteSpace(keyword), t => t.name.Contains(keyword)).ToList();
            dataGridView1.DataSource = datas;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IniDataGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SelectedPerons = new List<Person>();
            List<Person> persons = dataGridView1.DataSource as List<Person>;
            //获取选中的id列表
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                object obj = item.Cells[0].Value;
                if (obj != null && bool.Parse(obj.ToString()))
                {
                    SelectedPerons.Add(persons.Where(t => t.id == int.Parse(item.Cells[1].Value?.ToString())).FirstOrDefault());
                }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 选中的人员
        /// </summary>

        public List<Person> SelectedPerons { get; set; }
    }
}
