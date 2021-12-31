using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infoearth.Framework.SqlWinform.Attributes;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SqlSugar;

namespace Infoearth.Framework.SqlWinform
{
    /// <summary>
    /// 数据导出
    /// </summary>
    public static class Exporter
    {
        /// <summary>
        /// 保存集合数据到xls文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="studentList"></param>
        /// <param name="filePath"></param>
        public static void SaveDataToExcelFile<T>(this List<T> studentList, string filePath) where T : class,new()
        {
            IWorkbook workbook = GetWorkbook(studentList);
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    workbook.Write(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook.Close();
            }
        }

        /// <summary>
        /// 保存集合数据到xls文件流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="studentList"></param>
        /// <param name="filePath"></param>
        public static MemoryStream SaveDataToExcelStream<T>(this List<T> studentList) where T : class, new()
        {
            IWorkbook workbook = GetWorkbook(studentList);
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                workbook.Write(memoryStream);
                memoryStream.Position = 0;
            }
            catch (Exception ex)
            {
                //Log.WriteLog("保存到Excel失败", ex);
            }
            return memoryStream;
        }

        public static IWorkbook GetWorkbook<T>(this List<T> studentList)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();
            IRow row0 = sheet.CreateRow(0);

            PropertyInfo[] propertys = typeof(T).GetProperties();// 获得此模型的公共属性

            int col = 0;
            for (int j = 0; j < propertys.Length; j++)
            {
                if (j == 0)
                {
                    for (int k = 0; k < studentList.Count; k++)
                    {
                        IRow row = sheet.CreateRow(k + 1);
                    }
                }
                var exportAttr = propertys[j].GetCustomAttributes<SugarColumn>();
                GridColumnHidden hidden = propertys[j].GetCustomAttribute<GridColumnHidden>();
                if (hidden != null || exportAttr.Any(t => string.IsNullOrEmpty(t.ColumnDescription)))
                {
                    continue;
                }
                for (int i = 0; i < studentList.Count; i++)
                {
                    //设置表头
                    if (i == 0)
                    {
                        //读取属性
                        string columnName = exportAttr.Where(t => !string.IsNullOrEmpty(t.ColumnDescription)).Select(t => t.ColumnDescription).FirstOrDefault();
                        if (string.IsNullOrEmpty(columnName))
                        {
                            //读取注释
                            var descAttr = propertys[j].GetCustomAttributes<DescriptionAttribute>(true);
                            columnName = descAttr.Select(t => t.Description).FirstOrDefault();
                        }
                        row0.CreateCell(col).SetCellValue(columnName);
                    }
                    //属性转换
                    object value = propertys[j].GetValue(studentList[i], null);
                    string str = string.Empty;

                    if (value != null)
                        str = value.ToString();

                    sheet.GetRow(i + 1).CreateCell(col).SetCellValue(str);

                }
                col++;
            }
            return workbook;
        }
    }
}
