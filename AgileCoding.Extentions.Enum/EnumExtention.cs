namespace AgileCoding.Extentions.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class EnumExtention
    {
        public static EnumType SetWithStringValue<EnumType>(this EnumType enumType, string stringValue)
            where EnumType : System.Enum
        {
            return (EnumType)Enum.Parse(enumType.GetType(), stringValue, true);
        }

        public static EnumType SetWithStringValue<EnumType, IExceptionType>(this EnumType enumType, string stringValue, string errormessage = null)
            where EnumType : System.Enum
             where IExceptionType : Exception
        {
            if (string.IsNullOrEmpty(errormessage))
            {
                errormessage = $"Enum type {nameof(EnumType)} does not contain the enum value {stringValue}";
            }

            try
            {
                return (EnumType)Enum.Parse(enumType.GetType(), stringValue, true);
            }
            catch (Exception)
            {
                throw (IExceptionType)Activator.CreateInstance(typeof(IExceptionType), errormessage);
            }
        }

        public static bool ValidateEnumEqualToAny<TEnum, IExceptionType>(this TEnum enumType, IEnumerable<TEnum> enumValues, string errormessage = null)
            where TEnum : System.Enum
            where IExceptionType : Exception
        {
            if (string.IsNullOrEmpty(errormessage))
            {
                errormessage = $"Enum type {nameof(TEnum)} was not equal to any of the following values {string.Join(",", enumValues)}";
            }

            if (enumValues.Contains(enumType))
            {
                return true;
            }

            throw (IExceptionType)Activator.CreateInstance(typeof(IExceptionType), errormessage);
        }

        public static bool InAny<TEnum>(this TEnum enumType, params TEnum[] enumValues)
            where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("InAny requires a enum in the TEnum parameter");
            }

            return enumValues.Contains(enumType);
        }

        public static void ThrowIfEqualTo<TEnum, IExceptionType>(this TEnum enumType, TEnum enumToCompare, string errormessage = null)
            where TEnum : struct
            where IExceptionType : Exception
        {
            if (string.IsNullOrEmpty(errormessage))
            {
                errormessage = $"Enum type {nameof(TEnum)} was not equal to any of the following values {string.Join(",", enumToCompare)}";
            }

            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("ThrowIfEqualTo requires a enum in the TEnum parameter");
            }

            if (enumToCompare.ToString() == enumType.ToString())
            {
                throw (IExceptionType)Activator.CreateInstance(typeof(IExceptionType), errormessage);
            }
        }

        public static ANYType[] GetAllEnumsContainingAttribute<ANYType>(this ANYType genericType, Type TypeOfAttribute)
        {
            List<ANYType> listOfEnums = new List<ANYType>();
            Type genericEnumType = genericType.GetType();

            MemberInfo[] memberInfo = genericEnumType.GetMember(genericType.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(TypeOfAttribute, false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    listOfEnums.Add((ANYType)Enum.Parse(typeof(ANYType), memberInfo[0].Name));
                }
            }
            return listOfEnums.ToArray();
        }
    }
}
