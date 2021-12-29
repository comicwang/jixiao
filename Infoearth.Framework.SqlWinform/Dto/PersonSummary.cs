using Infoearth.Framework.SqlWinform.Attributes;
using Infoearth.Framework.SqlWinform.Entity;
using Infoearth.Framework.SqlWinform.extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Dto
{
    public class PersonSummary
    {
        [SqlSugar.SugarColumn(ColumnDescription = "编号")]
        public int id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "姓名")]
        public string name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "性别")]
        public Sex sex { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "科室")]
        public string room { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "职务")]
        public string position { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "联系方式")]
        public string phone { get; set; }

        /// <summary>
        /// 人员简介
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "人员介绍"), GridColumnHidden]
        public string description { get; set; }

        /// <summary>
        /// 普惠系数
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "普惠系数"), GridColumnHidden]
        public string personDelta { get; set; }

        /// <summary>
        /// 备注
        /// </summary
        [SqlSugar.SugarColumn(ColumnDescription = "备注"), GridColumnHidden]
        public string remark { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="已分次数")]
        public int AllotedTimes { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "已分总额"),GridColumnHidden]
        public int AllotedMoney { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "已分总额")]
        public string AllotedMoneyVal { get { return AllotedMoney.ToMoney(); } }

        [SqlSugar.SugarColumn(ColumnDescription = "主要次数"), GridColumnHidden]
        public int MainTimes { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "主要总额"), GridColumnHidden]
        public int MainMoney { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "主要总额"), GridColumnHidden]
        public string MainMoneyVal { get { return MainMoney.ToMoney(); } }

        [SqlSugar.SugarColumn(ColumnDescription = "普惠次数"), GridColumnHidden]
        public int CustomTimes { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "普惠总额"), GridColumnHidden]
        public int CustomMoney { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "普惠总额"), GridColumnHidden]
        public string CustomMoneyVal { get { return CustomMoney.ToMoney(); } }


        [SqlSugar.SugarColumn(ColumnDescription = "分配情况")]
        public string AllotedInfo { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "已兑现数")]
        public int CashedTimes { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "已兑总额"), GridColumnHidden]
        public int CashedMoney { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "已兑总额")]
        public string CashedMoneyVal { get { return CashedMoney.ToMoney(); } }

        [SqlSugar.SugarColumn(ColumnDescription = "未兑总额"), GridColumnHidden]
        public int NotCashedMoney { get { return AllotedMoney - CashedMoney; } }

        [SqlSugar.SugarColumn(ColumnDescription = "未兑总额")]
        public string NotCashedMoneyVal { get { return NotCashedMoney.ToMoney(); } }

        [SqlSugar.SugarColumn(ColumnDescription = "兑现情况")]
        public string CashedInfo { get; set; }
    }
}
