using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
   public static class Validator
    {
        public static bool  IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type objType = obj.GetType();
            PropertyInfo[] propertesInfos = objType.GetProperties();

            foreach (PropertyInfo  property in propertesInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();
                foreach (MyValidationAttribute myValidationAttribute in attributes)
                {
                    if (!myValidationAttribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
