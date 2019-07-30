using System;
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

        private IEnumerable<ValidationAttribute> _validationAttributes;
        public IEnumerable<ValidationAttribute> ValidationAttributes
        {
            get { return _validationAttributes ?? (_validationAttributes = Property.GetValidationAttributes()); }
        }

        public int? Min { get; set; }
        public int? Max { get; set; }
        public Type ParentModel { get; }
        public PropertyInfo Property { get; }

        public ModelProperty(Type parentModel, PropertyInfo property)
        {
            ParentModel = parentModel;
            Property = property;
        }

        public bool HasAttribute(Type attributeType)
        {
            foreach (var attribute in ValidationAttributes)
            {
                if (attributeType == attribute.GetType()) return true;
            }

            return false;
        }
    }
}
