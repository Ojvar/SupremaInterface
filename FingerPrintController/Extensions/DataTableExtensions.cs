using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FingerPrintController.Extensions
{
    public static partial class Extensions
    {
        #region Methods
        /// <summary>
        /// Convert data table row to List
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T>
        toModelList<T> (this DataTable table) where T : new()
        {
            List<T> result = new List<T> ();


            foreach (DataRow row
                     in table?.Rows)
            {
                T obj = new T ();

                Type objType = obj.GetType ();

                foreach (DataColumn column
                         in table?.Columns)
                {
                    PropertyInfo pInfo = objType.GetProperty (column.ColumnName);

                    if (pInfo == null)
                    {
                        continue;
                    }


                    try
                    {
                        pInfo.SetValue (obj,
                                        convertType (row[column.ColumnName]),
                                        null);
                    }
                    catch (Exception)
                    {
                    }
                }


                // Add to list
                result.Add (obj);
            }

            return result;
        }


        /// <summary>
        /// Converted type
        /// </summary>
        private static object
        convertType (object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }

            return value;
        }
    } 
    #endregion
}
