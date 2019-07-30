﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator
{
    public class ModelProperty
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
        public Type ParentModel { get; }
        public PropertyInfo Property { get; }
        public IEnumerable<ValidationAttribute> ValidationAttributes { get; }
        public bool IsRequired { get { return Min.HasValue || ValidationAttributes.Any(a => a.GetType() == typeof(RequiredAttribute)); } }

        public ModelProperty(Type parentModel, PropertyInfo property)
        {
            ParentModel = parentModel;
            Property = property;

            ValidationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute)).ToList().Cast<ValidationAttribute>();
        }

        public bool HasAttribute(Type attributeType)
        {
            foreach (var attribute in ValidationAttributes)
            {
                if (attributeType == attribute.GetType()) return true;
            }

            return false;
        }

        public ValidationAttribute GetAttribute(Type attributeType)
        {
            return ValidationAttributes.FirstOrDefault(a => a.GetType() == attributeType);
        }
    }
}
