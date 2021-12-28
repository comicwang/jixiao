using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Infoearth.Framework.SqlWinform
{
    public static class FormEx
    {
        /// <summary>
        /// 绑定控件数据源
        /// </summary>
        /// <param name="form"></param>
        /// <param name="bindingSource"></param>
        public static void BindFormDB(this Form form,BindingSource bindingSource)
        {
            Type type = bindingSource.DataSource.GetType();
            var props = type.GetProperties();
            if (props.Any(t => t.Name == "id"))
            {
                form.DataBindings.Add(new Binding("Tag", bindingSource, "id", true));
            }

            BindControl(form.Controls, type, bindingSource);
        }

        public static void BindControlDB(this Control control, BindingSource bindingSource,Type type)
        {
            var props = type.GetProperties();
            if (props.Any(t => t.Name == "id"))
            {
                control.DataBindings.Add(new Binding("Tag", bindingSource, "id", true));
            }

            BindControl(control.Controls, type, bindingSource);
        }

        private static void BindControl(ControlCollection controlCollection, Type bindType, BindingSource bindingSource)
        {
            var props = bindType.GetProperties();
            foreach (Control item in controlCollection)
            {
                var findData = props.Where(t => item.Name.ToLower().Contains(t.Name.ToLower())).FirstOrDefault();
                if (findData != null)
                {
                    if (item.GetType() == typeof(ComboBox))
                    {
                        item.DataBindings.Add(new Binding("Text", bindingSource, CutPrev(UlityCons.ComboxPrev, findData.Name), true));
                    }
                    else if (item.GetType() == typeof(TextBox))
                    {
                        item.DataBindings.Add(new Binding("Text", bindingSource, CutPrev(UlityCons.TextPrev, findData.Name), true));
                    }
                    else if (item.GetType() == typeof(Label))
                    {
                        item.DataBindings.Add(new Binding("Text", bindingSource, CutPrev(UlityCons.LabelPrev, findData.Name), true));
                    }
                    else if (item.GetType() == typeof(DateTimePicker))
                    {
                        item.DataBindings.Add(new Binding("Value", bindingSource, CutPrev(UlityCons.DateTimePrev, findData.Name), true));
                    }
                }

                if (item.Controls.Count > 0)
                {
                    BindControl(item.Controls, bindType, bindingSource);
                }
            }
        }


        private static string CutPrev(string prev,string input)
        {
            if (input.StartsWith(prev))
                return input.Remove(0, prev.Length);

            return input;
        }
    }
}
