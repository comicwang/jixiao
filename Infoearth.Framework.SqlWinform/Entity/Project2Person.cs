using Infoearth.Framework.SqlWinform.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Entity
{
    public class Project2Person : GridViewEntity
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "编号")]
        public int id { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "所属项目"), GridColumnHidden]
        public int prid { get; set; }


        [SqlSugar.SugarColumn(IsIgnore = true, ColumnDescription = "姓名")]
        public string personName { get { return person.name; } }

        [SqlSugar.SugarColumn(IsIgnore = true, ColumnDescription = "科室")]
        public string personRoom { get { return person.room; } }

        [SqlSugar.SugarColumn(IsIgnore = true, ColumnDescription = "职务")]
        public string personPositon { get { return person.position; } }


        [SqlSugar.SugarColumn(ColumnDescription = "分配人编号"), GridColumnHidden]
        public int peid { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "分配类型")]
        public allotEnum allot { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "分配时间"), GridColumnHidden]
        public DateTime allotime { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "分配系数")]
        public double delta { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription = "分配金额(元)")]
        public double money { get; set; }

        [SqlSugar.SugarColumn(IsIgnore = true)]
        public Person person { get; set; }

        [SqlSugar.SugarColumn(IsIgnore = true)]
        public Project project { get; set; }
    }


    public enum allotEnum
    {
        主要 = 60,
        普惠 = 40
    }
}
