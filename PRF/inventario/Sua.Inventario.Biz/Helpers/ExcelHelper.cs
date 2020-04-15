using Excel;
using log4net.Repository.Hierarchy;
using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Helpers
{
    public class ExcelHelper
    {
        public ExcelHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public DataSet ConvertirExcelADataSet(byte[] file, bool primeraFilaCabecera)
        {
            try
            {
                MemoryStream fileStream = null;
                IExcelDataReader excelReader = null;

                try
                {
                    fileStream = new MemoryStream(file);
                    //Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                }
                catch
                {
                    fileStream = new MemoryStream(file);
                    //Excel file ('97-2003 format; *.xls)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                }

                excelReader.IsFirstRowAsColumnNames = primeraFilaCabecera;

                var result = excelReader.AsDataSet();

                excelReader.Close();
                excelReader.Dispose();
                fileStream.Close();
                fileStream.Dispose();

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Formato de Excel no válido");
            }
        }
    }

    public static class Helper
    {
        public static T ToObject<T>(this DataRow dataRow)
         where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName.ToLower());

                if (property != null && dataRow[column] != DBNull.Value)
                {
                    object result = Convert.ChangeType(dataRow[column], property.PropertyType);
                    property.SetValue(item, result, null);
                }
            }

            return item;
        }
    }
}
