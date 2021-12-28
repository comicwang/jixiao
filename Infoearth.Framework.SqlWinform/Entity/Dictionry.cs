using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Entity
{
    /// <summary>
    /// 系统通用字典
    /// </summary>
    public class Dictionry
    {
        [SqlSugar.SugarColumn(IsPrimaryKey=true,IsIdentity =true)]
        public int id { get; set; }

        /// <summary>
        /// 字典分类
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// 字典code
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        public string value { get; set; }
    }
}
