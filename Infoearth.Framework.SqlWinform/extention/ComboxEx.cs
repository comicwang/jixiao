using Infoearth.Framework.SqlWinform.Entity;
using Infoearth.Framework.SqlWinform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoearth.Framework.SqlWinform
{
    /// <summary>
    /// 
    /// </summary>
    public static class ComboxEx
    {
        /// <summary>
        /// 绑定输入的字典项
        /// </summary>
        /// <param name="comboBox"></param>
        public static void BindInput(this ComboBox comboBox)
        {
            if (comboBox.DropDownStyle == ComboBoxStyle.DropDownList)
                return;

            comboBox.Leave += ComboBox_Leave;
        }

        /// <summary>
        /// 根据数据库初始化字典
        /// </summary>
        /// <param name="comboBox"></param>
        public static void BindDb(this ComboBox comboBox)
        {
            DictionaryManager manager = new DictionaryManager();
            var datas = manager.CurrentDb.AsQueryable().Where(t => t.model == CutPrev(comboBox.Name)).ToList();
            comboBox.DataSource = datas;
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "key";
        }

        private static string CutPrev(string input)
        {
            if (input.StartsWith(UlityCons.ComboxPrev))
                return input.Remove(0, 5);

            return input;
        }

        private static void ComboBox_Leave(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            var current = cb.Text;
            if (string.IsNullOrWhiteSpace(current))
                return;
            bool found = false;
            foreach (var item in cb.Items)
            {
                if (current == ((Dictionry)item).key)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                //加入数据库字典
                DictionaryManager manager = new DictionaryManager();
                bool added = manager.CurrentDb.Insert(new Entity.Dictionry()
                {
                    model = CutPrev(cb.Name),
                    key = current,
                    value = current
                });
                var datas = manager.CurrentDb.AsQueryable().Where(t => t.model == CutPrev(cb.Name)).ToList();
                cb.DataSource = datas;
                cb.SelectedValue = current;
            }
        }
    }
}
