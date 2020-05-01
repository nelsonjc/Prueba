namespace WebPlatform.Data.Helper
{
    using Microsoft.Data.SqlClient;
    using System;


    public class ParameterHelper
    {
        public static SqlParameter NewParameter(string ParameterName, System.Data.SqlDbType sqlDbType, int size, System.Data.ParameterDirection parameterDirection, object value)
        {
            var parameter = new SqlParameter
            {
                SqlDbType = sqlDbType,
                ParameterName = ParameterName,
                Direction = parameterDirection,
                Size = size > 0 ? size : default(int),
                Value = value ?? DBNull.Value
            };

            return parameter;
        }
    }
}
