using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator.DimensionAttributeHandler
{
    public class StringLenghtHandler : IDimensionAttributeHandler
    {
        public Type HandledAttribute { get; } = typeof(StringLengthAttribute);

        public PropertyDimension AddDimension(PropertyDimension size, ValidationAttribute attribute)
        {
            size.SetMax( ((StringLengthAttribute)attribute).MaximumLength );

            var min = ((StringLengthAttribute)attribute).MinimumLength;

            if (min > 0) size.SetMin( ((StringLengthAttribute)attribute).MinimumLength );

            return size;
        }
    }
}
