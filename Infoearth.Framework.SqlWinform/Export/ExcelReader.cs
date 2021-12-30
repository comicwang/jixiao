using Infoearth.Framework.SqlWinform.Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Infoearth.Framework.SqlWinform
{
    public static class ExcelReader
    {
        public static OleDbConnection GetOleDbConnection(string excelPath)
        {
            string conStr = "Provider=Microsoft.jet.oledb.4.0;data source=" + excelPath + ";extended properties='Excel 8.0;HDR=yes;IMEX=1'";
            string conStrX = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + excelPath + ";Extended Properties='Excel 12.0;HDR=yes;IMEX=1'";

            OleDbConnection con = null;
            try
            {
                if (excelPath.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
                {
                    con = new OleDbConnection(conStr);
                }
                else if (excelPath.EndsWith(".xlsx", StringComparison.CurrentCultureIgnoreCase))
                {
                    con = new OleDbConnection(conStrX);
                }
                else if (excelPath.EndsWith(".xlsb", StringComparison.CurrentCultureIgnoreCase))
                {
                    con = new OleDbConnection(conStrX);
                }
                else
                {
                    throw new Exception("不支持的excel文件格式");
                }
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return con;
        }

        public static List<string> GetExcelSheetName(string excelPath)
        {
            OleDbConnection con = GetOleDbConnection(excelPath);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //获取sheets名称
            DataTable schamaTbl = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            List<string> sheetsList = new List<string>();
            for (int i = 0; i < schamaTbl.Rows.Count; i++)
            {
                sheetsList.Add(schamaTbl.Rows[i]["TABLE_NAME"].ToString());
            }
            con.Close();
            return sheetsList;
        }

        public static DataTable GetExcelContext(string excelPath, string sheetName)
        {
            OleDbConnection con = GetOleDbConnection(excelPath);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string cmdStr = "select * from [" + sheetName + "]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdStr, con);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            con.Close();
            DataTable table = dataSet.Tables[0];
            adapter.Dispose();

            return table;
        }

        /// <summary>
        /// 获取sheet文件转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelPath"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static List<T> GetExcelContent<T>(string excelPath,string sheetName) where T:class,new()
        {
            DataTable dataTable = GetExcelContext(excelPath, sheetName);

            List<T> result = new List<T>();

            foreach (DataRow item in dataTable.Rows)
            {
                T temp = new T();
                PropertyInfo[] props = typeof(T).GetProperties();
                foreach (DataColumn column in dataTable.Columns)
                {
                   var prop= props.Where(t => t.GetCustomAttribute<SugarColumn>() != null && t.GetCustomAttribute<SugarColumn>().ColumnDescription == column.ColumnName).FirstOrDefault();
                    if (prop != null)
                    {
                        if (prop.PropertyType == typeof(Sex))
                        {
                            Sex sex = Sex.男;
                            bool success = Enum.TryParse(item[column]?.ToString(), out sex);
                            if (success)
                                prop.SetValue(temp, sex);
                        }
                        else if (prop.PropertyType == typeof(double))
                        {
                            double tmp = 0;
                            bool success = double.TryParse(item[column]?.ToString(), out tmp);
                            if (success)
                                prop.SetValue(temp,Math.Round(tmp,2));
                        }
                        else if (prop.PropertyType == typeof(string))
                            prop.SetValue(temp, item[column]?.ToString());
                        else if (prop.PropertyType == typeof(int))
                        {
                            int year = 0;
                            bool success = int.TryParse(item[column]?.ToString(), out year);
                            if (success)
                            {
                                prop.SetValue(temp, year);
                            }
                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {
                            DateTime year = DateTime.MinValue;
                            bool success = DateTime.TryParse(item[column]?.ToString(), out year);
                            if (success)
                            {
                                prop.SetValue(temp, year);
                            }
                        }
                        else
                            prop.SetValue(temp, item[column]);
                    }
                }
                result.Add(temp);
            }
            return result;
        }
    }
}
