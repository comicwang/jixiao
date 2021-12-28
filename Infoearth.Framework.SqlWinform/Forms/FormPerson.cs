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
    public partial class FormPerson : Form
    {
        private PersonManager _personManager = new PersonManager();
        private Person _person = new Person();
        private bool _add = true;
        public FormPerson()
        {
            InitializeComponent();
            this.bindingSource1.DataSource = _person;
        }

        public FormPerson(Person person) : this()
        {
            _person = person;
            _add = false;
            this.bindingSource1.DataSource = _person;
        }

        private void FormPerson_Load(object sender, EventArgs e)
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
            Person SaveData = this.bindingSource1.DataSource as Person;
            if (_add)
                _personManager.Insert(SaveData);
            else
                _personManager.Update(SaveData);
            this.DialogResult = DialogResult.OK;
        }
    }
}
