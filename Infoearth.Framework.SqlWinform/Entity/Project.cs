using Infoearth.Framework.SqlWinform.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Entity
{
    public class Project : GridOprateEntity
    {
        [SqlSugar.SugarColumn(IsPrimaryKey =true,IsIdentity =true,ColumnDescription ="编号")]
        public int id { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="项目名称")]
        public string name { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="年份")]
        public int year { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="绩效组")]
        public string group { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="主要参与部门")]
        public string room { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="主要参与人员")]
        public string persons { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="绩效总奖金（元）")]
        public double memony { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="备注"), GridColumnHidden]
        public string remark { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="已分配金额（元）"), GridColumnHidden]
        public double allotMoney { get; set; }

        [SqlSugar.SugarColumn(IsIgnore =true,ColumnDataType ="已全额分配"), GridColumnHidden]
        public bool alloted { get { return allotMoney == memony; } }
    }
}
