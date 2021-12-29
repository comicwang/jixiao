using Infoearth.Framework.SqlWinform.Dto;
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
    public partial class FormPersonSummary : Form
    {
        private ProjectManager _projectManager = new ProjectManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private PersonManager _personManager = new PersonManager();
        private Money2PersonManager _p2mManager = new Money2PersonManager();

        private int _personId = 0;

        public FormPersonSummary(int personId)
        {
            _personId = personId;

            InitializeComponent();
            this.bindingSource1.DataSource = new PersonSummary();
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            //绑定所有下拉框
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(ComboBox))
                {
                    ComboBox comboBox = item as ComboBox;
                    comboBox.BindDb();
                    comboBox.BindInput();
                    comboBox.Enabled = false;
                }
                else if(item.GetType()==typeof(TextBox))
                {
                    (item as TextBox).ReadOnly = true;
                }
            }

            this.BindFormDB(this.bindingSource1);

            var persons = _personManager.CurrentDb.GetById(_personId);

            this.Text = $"{persons.name}的个人绩效详情";

            var p2pInfo = _p2pManager.CurrentDb.AsQueryable().Where(t => t.peid == _personId).ToList();
            var projects = _projectManager.CurrentDb.AsQueryable().Select(t => new Project() { id = t.id, name = t.name }).ToList();
            var p2mInfos = _p2mManager.CurrentDb.GetList();
            foreach (var item in p2pInfo)
            {
                item.project = projects.Where(t => t.id == item.prid).FirstOrDefault();
            }


            PersonSummary personSummary = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonSummary>(Newtonsoft.Json.JsonConvert.SerializeObject(persons));

            personSummary.AllotedTimes = p2pInfo.Count();
            personSummary.AllotedMoney = p2pInfo.Sum(t => t.money);
            personSummary.MainTimes = p2pInfo.Where(t => t.allot == allotEnum.主要).Count();
            personSummary.MainMoney = p2pInfo.Where(t => t.allot == allotEnum.主要).Sum(t => t.money);
            personSummary.CustomTimes = p2pInfo.Where(t => t.allot == allotEnum.普惠).Count();
            personSummary.CustomMoney = p2pInfo.Where(t => t.allot == allotEnum.普惠).Sum(t => t.money);
            personSummary.AllotedInfo = string.Join("\r\n", p2pInfo.Select(t => t.project.name + "(" + t.allot + "):" + t.money.ToMoney()));

            var p2mInfo = p2mInfos.Where(t => t.peid == persons.id);
            personSummary.CashedMoney = p2mInfo.Sum(t => t.cashMoney);
            personSummary.CashedTimes = p2mInfo.Count();
            personSummary.CashedInfo = string.Join("\r\n", p2mInfo.Select(t => t.cashGroup + ":" + t.cashMoney.ToMoney()));
            this.bindingSource1.DataSource = personSummary;
        }
    }
}
