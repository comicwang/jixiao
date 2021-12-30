using Infoearth.Framework.SqlWinform.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Entity
{
    [SqlSugar.SugarTable("Person")]
    public class Person : GridOprateEntity
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true,ColumnDescription ="编号")]
        public int id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription ="姓名")]
        public string name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "性别")]
        public Sex sex { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "领域分类")]
        public string room { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "职务")]
        public string position { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "学历")]
        public string education { get; set; }     

        /// <summary>
        /// 联系方式
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "联系方式")]
        public string phone { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="工资级别")]
        public string level { get; set; }

        [SqlSugar.SugarColumn(ColumnDescription ="个人系数")]
        public double persondelta { get; set; }

        /// <summary>
        /// 人员简介
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDescription = "人员介绍"), GridColumnHidden]
        public string description { get; set; }

        /// <summary>
        /// 备注
        /// </summary
        [SqlSugar.SugarColumn(ColumnDescription = "备注")]
        public string remark { get; set; }
    }


    public enum Sex
    {
        男 = 0,
        女 = 1,
        不明 = 2
    }
}
