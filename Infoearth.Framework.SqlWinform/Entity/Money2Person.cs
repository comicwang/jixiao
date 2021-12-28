using Infoearth.Framework.SqlWinform.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Entity
{
    public class Money2Person : GridOprateEntity
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "编号")]
        public int id { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "人员编号"), GridColumnHidden]
        public int peid { get; set; }

        [SqlSugar.SugarColumn(IsIgnore =true,ColumnDescription = "姓名")]
        public string name { get { return person?.name; } }

        [SqlSugar.SugarColumn(IsIgnore = true, ColumnDescription = "兑现人"),GridColumnHidden]
        public string cashName { get; set; }

        [SqlSugar.SugarColumn(IsIgnore = true, ColumnDescription = "科室")]
        public string room { get { return person?.room; } }

        [SqlSugar.SugarColumn(IsIgnore = true, ColumnDescription = "职称")]
        public string postion { get { return person?.position; } }

        [SqlSugar.SugarColumn(ColumnDescription = "兑现分组")]
        public string cashGroup { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "兑现时间")]
        public DateTime cashTime { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "兑现金额")]
        public int cashMoney { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "备注")]
        public string remark { get; set; }

        [SqlSugar.SugarColumn(IsIgnore = true), GridColumnHidden]
        public Person person { get; set; }
    }
}
