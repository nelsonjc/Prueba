using System;
using System.ComponentModel;
namespace WebPlatform.Business
{
    using System.Reflection;

    public enum SqlErrorCategory
    {
        [Description("Error generado por base de datos con código {0}")]
        ErrorGeneral = 0,

        [Description("El registro ya existe en la base de datos")]
        ErrorConstraint = 2627
    }

    public static class SqlMessageErrorGenerator
    {
        public static string GetMessageError(int ErrorCode)
        {
            string messageError = string.Empty;
            SqlErrorCategory[] values = (SqlErrorCategory[])Enum.GetValues(typeof(SqlErrorCategory));


            foreach (SqlErrorCategory val in values)
            {
                if ((int)val == ErrorCode)
                    messageError = GetEnumDescription(val);
            }

            if (string.IsNullOrEmpty(messageError))
                messageError = GetEnumDescription(SqlErrorCategory.ErrorGeneral).Replace("{0}", ErrorCode.ToString());


            return messageError;
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }

}
