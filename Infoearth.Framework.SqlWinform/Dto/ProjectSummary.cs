using Infoearth.Framework.SqlWinform.Attributes;
using Infoearth.Framework.SqlWinform.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infoearth.Framework.SqlWinform.extention;

namespace Infoearth.Framework.SqlWinform.Dto
{
    public class ProjectSummary
    {
        [SqlSugar.SugarColumn(ColumnDescription = "编号")]
        public int id { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "项目名称")]
        public string name { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "年份")]
        public int year { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "绩效组")]
        public string group { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "主要参与部门")]
        public string room { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "主要参与人员")]
        public string persons { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "绩效总奖金（元）"),GridColumnHidden]
        public double memony { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "绩效总奖金（元）")]
        public string memonyVal { get { return memony.ToMoney(); } }

        [SqlSugar.SugarColumn(ColumnDescription = "主要分配人员")]
        public string mainPersons { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "主要分配情况")]
        public string mainAllotedInfo { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "其他分配人数")]
        public int otherPersonCount { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "其他分配情况")]
        public string otherAllotedInfo { get; set; }


        [SqlSugar.SugarColumn(ColumnDescription = "总分配金额（元）"),GridColumnHidden]
        public double allotMoney { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "总分配金额（元）")]
        public string allotMoneyVal { get { return allotMoney.ToMoney(); } }

        [SqlSugar.SugarColumn(ColumnDescription = "已分配完成")]
        public string alloted { get { return allotMoney == memony ? "是" : "否"; } }

        [SqlSugar.SugarColumn(IsIgnore = true), GridColumnHidden]
        public int Grid_Num { get; set; }

    }
}
