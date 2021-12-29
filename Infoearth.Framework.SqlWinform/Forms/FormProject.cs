using Infoearth.Framework.SqlWinform.Entity;
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
    public partial class FormProject : Form
    {
        private ProjectManager _ProjectManager = new ProjectManager();
        private Project _Project = new Project();
        private bool _add = true;
        public FormProject()
        {
            InitializeComponent();
            this.bindingSource1.DataSource = _Project;
        }

        public FormProject(Project Project) : this()
        {
            _Project = Project;
            _add = false;
            this.bindingSource1.DataSource = _Project;
        }

        private void FormProject_Load(object sender, EventArgs e)
        {
            //绑定所有下拉框
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(ComboBox))
                {
                    ComboBox comboBox = item as ComboBox;
                    comboBox.BindDb();
                    comboBox.BindInput();
                }
            }

            this.BindFormDB(this.bindingSource1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Project SaveData = this.bindingSource1.DataSource as Project;
            if (_add)
                _ProjectManager.Insert(SaveData);
            else
                _ProjectManager.Update(SaveData);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
