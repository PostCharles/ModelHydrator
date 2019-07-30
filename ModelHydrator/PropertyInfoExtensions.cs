using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace ModelHydrator
{
    internal static class PropertyInfoExtensions
    {
        internal static IEnumerable<ValidationAttribute> GetValidationAttributes(this PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(ValidationAttribute));

            return attributes.ToList().Cast<ValidationAttribute>();
        }
    }
}
