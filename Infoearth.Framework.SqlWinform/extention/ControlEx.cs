using Infoearth.Framework.SqlWinform.Attributes;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoearth.Framework.SqlWinform.extention
{
    public static class ControlEx
    {
        public static void BindDb<T>(this DataGridView dataGridView, Action refreash = null, bool needCheck = false, bool getChild = false) where T : class, new()
        {
            Type type = typeof(T);
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.Clear();
            if (needCheck)
            {
                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                column.DataPropertyName = "checkGrid_info";
                column.HeaderText = "";
                column.Name = "checkGrid_info" + "DataGridViewCheckBoxColumn";
                column.Width = 15;
                dataGridView.Columns.Add(column);
            }

            GetColumns(type, dataGridView, getChild);
            dataGridView.CellEndEdit += (sender, e) =>
            {
                var datas = dataGridView.DataSource as List<T>;
                if (datas == null || datas.Count == 0)
                    return;
                var current = datas[e.RowIndex];

                bool success = new DbContext<T>().Update(current);

                if (!success)
                {
                    if (refreash != null)
                    {
                        refreash();
                    }
                }
            };
        }

        public static void BindDb<T>(this DataGridView dataGridView, params Action[] actions) where T : class, new()
        {
            Type type = typeof(T);
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.Clear();

            GetColumns(type, dataGridView, false);
            dataGridView.CellEndEdit += (sender, e) =>
            {
                var datas = dataGridView.DataSource as List<T>;
                if (datas == null || datas.Count == 0)
                    return;
                var current = datas[e.RowIndex];

                bool success = new DbContext<T>().Update(current);

                if (actions != null && actions.Length > 0)
                {
                    foreach (var item in actions)
                    {
                        if (item != null)
                            item();
                    }
                }
            };
        }



        private static void GetColumns(Type type, DataGridView dataGridView, bool GetChild)
        {
            var props = type.GetProperties();

            foreach (PropertyInfo item in props)
            {
                if (item.PropertyType.IsValueType || item.PropertyType == typeof(string))
                {
                    SugarColumn attr = item.GetCustomAttribute<SqlSugar.SugarColumn>();
                    if (attr == null)
                        return;
                    GridColumnHidden hidden = item.GetCustomAttribute<GridColumnHidden>();
                    if (!string.IsNullOrEmpty(attr.ColumnDescription))
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.DataPropertyName = item.Name;
                        column.HeaderText = attr.ColumnDescription;
                        column.Name = item.Name + "DataGridViewTextBoxColumn";
                        column.MinimumWidth = 6;
                        column.Visible = hidden == null;
                        dataGridView.Columns.Add(column);
                    }
                    else
                    {
                        DataGridViewLinkColumn column = new DataGridViewLinkColumn();
                        column.DataPropertyName = item.Name;
                        column.HeaderText = attr.ColumnDescription;
                        column.Name = item.Name + "DataGridViewLinkColumn";
                        column.Width = 15;
                        column.HeaderText = "";
                        column.ReadOnly = true;
                        column.FillWeight = 50;
                        column.Resizable = DataGridViewTriState.False;
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                        column.Visible = hidden == null;
                        dataGridView.Columns.Add(column);
                    }
                }
                else
                {
                    if (GetChild)
                        GetColumns(item.PropertyType, dataGridView, GetChild);
                }
            }
        }
    }
}
