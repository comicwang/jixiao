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
    public partial class FormMoney2Person : Form
    {
        private Money2PersonManager _p2mManager = new Money2PersonManager();
        private PersonManager _personManager = new PersonManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private Money2Person _person = new Money2Person();
        private bool _add = true;
        public FormMoney2Person()
        {
            InitializeComponent();
            this.bindingSource1.DataSource = _person;
        }

        public FormMoney2Person(Money2Person Money2Person) : this()
        {
            _person = Money2Person;
            _add = false;
            this.bindingSource1.DataSource = _person;
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            //绑定所有下拉框
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(ComboBox))
                {
                    if (item.Name == comboBox2.Name)
                        continue;
                    ComboBox comboBox = item as ComboBox;
                    comboBox.BindDb();
                    comboBox.BindInput();
                }
            }

            var persons = _personManager.CurrentDb.AsQueryable().ToList();

            comboBox2.DataSource = persons;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";

            if (_person.person != null)
                comboBox2.SelectedItem = _person.person;

            this.BindFormDB(this.bindingSource1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Money2Person SaveData = this.bindingSource1.DataSource as Money2Person;
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
                return;
            SaveData.peid = int.Parse(comboBox2.Tag.ToString());
            if (_add)
                _p2mManager.Insert(SaveData);
            else
                _p2mManager.Update(SaveData);
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person person = comboBox2.SelectedItem as Person;
            comboRoom.Text = person.room;
            comboPosition.Text = person.position;
            comboBox2.Tag = person.id;

            double all = _p2pManager.CurrentDb.AsQueryable().Where(t => t.peid == person.id).Sum(t => t.money);

            double cashed = _p2mManager.CurrentDb.AsQueryable().Where(t => t.peid == person.id).Sum(t => t.cashMoney);

            txtAll.Text = all.ToMoney();
            txtAlloted.Text = cashed.ToMoney();
            txtLeft.Text = (all - cashed).ToMoney();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
