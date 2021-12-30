using Infoearth.Framework.SqlWinform.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infoearth.Framework.SqlWinform.extention;

namespace Infoearth.Framework.SqlWinform.Dto
{
    /// <summary>
    /// 分配金额总计
    /// </summary>
    public class MoneySummary
    {
        private List<Project2Person> _datas;

        public MoneySummary(List<Project2Person> project2People)
        {
            _datas = project2People;
        }

        /// <summary>
        /// 金额总数
        /// </summary>
        public double TotalMoneyVal { get; set; }

        public string TotalMoney { get { return TotalMoneyVal.ToMoney(); } }

        /// <summary>
        /// 已分配金额总数
        /// </summary>
        public double AllotedMoneyVal { get { return _datas == null ? 0 : _datas.Sum(t => t.money).ToEnd(); } }

        public string AllotedMoney { get { return AllotedMoneyVal.ToMoney(); } }

        /// <summary>
        /// 剩余金额总数
        /// </summary>
        public double LeftMoneyVal { get { return _datas == null ? 0 : (TotalMoneyVal - _datas.Sum(t => t.money)).ToEnd(); } }

        public string LeftMoney { get { return LeftMoneyVal.ToMoney(); } }

        /// <summary>
        /// 主要分配总额
        /// </summary>
        public double MainMoneyVal { get { return (TotalMoneyVal * (((int)allotEnum.主要)) / 100).ToEnd(); } }

        public string MainMoney { get { return MainMoneyVal.ToMoney(); } }

        /// <summary>
        /// 主要总额已分配数
        /// </summary>
        public double MainAllotedVal { get { return _datas == null ? 0 : _datas.Where(t => t.allot == allotEnum.主要).Sum(t => t.money).ToEnd(); } }

        public string MainAlloted { get { return MainAllotedVal.ToMoney(); } }

        /// <summary>
        /// 主要总额未分配数
        /// </summary>
        public double MainLeftVal { get { return MainMoneyVal - MainAllotedVal; } }

        public string MainLeft { get { return MainLeftVal.ToMoney(); } }

        /// <summary>
        /// 普惠总金额
        /// </summary>
        public double CustomMoneyVal { get { return (TotalMoneyVal * (((int)allotEnum.普惠)) / 100).ToEnd(); } }

        public string CustomMoney { get { return CustomMoneyVal.ToMoney(); } }

        /// <summary>
        /// 普惠已分配额
        /// </summary>
        public double CustomAllotedVal { get { return _datas == null ? 0 : _datas.Where(t => t.allot == allotEnum.普惠).Sum(t => t.money).ToEnd(); } }

        public string CustomAlloted { get { return CustomAllotedVal.ToMoney(); } }

        /// <summary>
        /// 普惠未分配额度
        /// </summary>
        public double CustomLeftVal { get { return CustomMoneyVal - CustomAllotedVal; } }

        public string CustomLeft { get { return CustomLeftVal.ToMoney(); } }
    }
}
