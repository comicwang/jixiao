using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.extention
{
    public static class MoneyDisplay
    {
        public static string ToMoney(this int money)
        {
            int index = 1;
            string result = string.Empty;
            for (int i = money.ToString().Length - 1; i >= 0; i--)
            {
                result += money.ToString()[i];
                if (index % 3 == 0)
                {
                    result += ",";
                }
                index++;
            }
            result= result.TrimEnd(',');
            result += " ¥";

            return string.Concat(result.Reverse());
        }

        public static string ToMoney(this double money1)
        {
            money1 = Math.Round(money1, 2);

            int money = (int)Math.Floor(money1);
            int index = 1;
            string result = string.Empty;
            for (int i = money.ToString().Length - 1; i >= 0; i--)
            {
                result += money.ToString()[i];
                if (index % 3 == 0)
                {
                    result += ",";
                }
                index++;
            }
            result = result.TrimEnd(',');
            result += " ¥";

            return string.Concat(result.Reverse()) + (money1.ToString().IndexOf('.') != -1 ? money1.ToString().Remove(0, money1.ToString().LastIndexOf('.')) : string.Empty);
        }

        public static double ToEnd(this double money)
        {
            return Math.Round(money, 2);
        }
    }
}
