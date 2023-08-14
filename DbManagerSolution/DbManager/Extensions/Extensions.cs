using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Extensions
{
    public static class Extensions
    {
        public static string ColumnName(this PropertyInfo propertyInfo)
        {
            var columnAttribute = (SqlKata.Column)propertyInfo.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(SqlKata.Column));
            return columnAttribute?.Name;
        }
    }
}
