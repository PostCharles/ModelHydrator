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

        public (int? Min, int? Max) GetDimension(ValidationAttribute attribute)
        {
            int? max = ( ((StringLengthAttribute)attribute).MaximumLength );

            int? min = ((StringLengthAttribute)attribute).MinimumLength;

            if (min > 0) min = ( ((StringLengthAttribute)attribute).MinimumLength );

            return (min, max);
        }
    }
}
