using System;

namespace DoubleJ.Oms.Utils.Extensions
{
    public static class ValueTypeExt
    {
        public static bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static T GetAbsOrDefault<T>(this T? value) where T : struct
        {
            if (!value.HasValue) return default(T);
            if (!value.IsNumericType()) return value.Value;
            return Math.Abs((dynamic)value.Value);
        }

        public static int AsQuantity(this int? value)
        {
            return value.HasValue ? AsQuantity(value.Value) : 1;
        }

        public static int AsQuantity(this int value)
        {
            return value == 0 ? 1 : value;
        }
    }
}
