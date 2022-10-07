using System.ComponentModel;

namespace SB.Library.Enum
{
    public static class EnumHelper<T>
    {
        public static string getEnumDescription(T val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
