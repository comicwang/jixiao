using Infoearth.Framework.SqlWinform.Dto;
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

namespace Infoearth.Framework.SqlWinform.Controls
{
    public partial class ControlFristPage : UserControl
    {
        private ProjectManager _projectManager = new ProjectManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private PersonManager _personManager = new PersonManager();

        public ControlFristPage()
        {
            InitializeComponent();
        }

        private void ControlFristPage_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.DataBindXY(new string[] { "已分配完成", "未分配完成", "未开始分配" }, new int[] {
                _projectManager.CurrentDb.AsQueryable().Where(t => t.allotMoney == t.memony).Count(),
                _projectManager.CurrentDb.AsQueryable().Where(t => t.allotMoney > 0 && t.allotMoney != t.memony).Count(),
                 _projectManager.CurrentDb.AsQueryable().Where(t => t.allotMoney == 0).Count()
            });

            var projects= _projectManager.CurrentDb.AsQueryable().OrderBy(t => t.memony, SqlSugar.OrderByType.Desc).Take(10).ToList();

            chart2.DataSource = projects;
            chart2.Series[0].YValueMembers = "memony";
            chart2.Series[0].XValueMember = "name";

            var p2pInfos = _p2pManager.CurrentDb.AsQueryable().GroupBy(t => t.peid).Select(t => new { id = t.peid, money = SqlSugar.SqlFunc.AggregateSum(t.money) }).OrderBy(t => t.money, SqlSugar.OrderByType.Desc).Take(10).ToList();
            var person = _personManager.CurrentDb.AsQueryable().In(t => t.id, p2pInfos.Select(s => s.id).ToArray()).ToList();

            List<StaticsInfo> result = new List<StaticsInfo>();
            foreach (var item in p2pInfos)
            {
                result.Add(new StaticsInfo()
                {
                    Value = item.money,
                    Name = person.Where(t => t.id == item.id).Select(t => t.name).FirstOrDefault()
                });
            }

            chart3.DataSource = result;
            chart3.Series[0].YValueMembers = "Value";
            chart3.Series[0].XValueMember = "Name";


            var p2pTimes = _p2pManager.CurrentDb.AsQueryable().GroupBy(t => t.peid).Select(t => new { id = t.peid, money = SqlSugar.SqlFunc.AggregateCount(t) }).OrderBy(t => t.money, SqlSugar.OrderByType.Desc).Take(10).ToList();
            var persons = _personManager.CurrentDb.AsQueryable().In(t => t.id, p2pTimes.Select(s => s.id).ToArray()).ToList();

            List<StaticsInfo> result1 = new List<StaticsInfo>();
            foreach (var item in p2pTimes)
            {
                result1.Add(new StaticsInfo()
                {
                    Value = item.money,
                    Name = person.Where(t => t.id == item.id).Select(t => t.name).FirstOrDefault()
                });
            }

            chart4.DataSource = result1;
            chart4.Series[0].YValueMembers = "Value";
            chart4.Series[0].XValueMember = "Name";
        }


    }
}
