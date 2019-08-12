using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator.DimensionAttributeHandlers
{
    public class StringLenghtHandler : IDimensionAttributeHandler
    {
        public Type HandledAttribute { get; } = typeof(StringLengthAttribute);

        public (int? Min, int? Max) GetDimension(ValidationAttribute attribute)
        {
            int? max = ((StringLengthAttribute)attribute).MaximumLength;

            int? min = new int?();

            if (((StringLengthAttribute)attribute).MinimumLength > 0)
            {
                min = ((StringLengthAttribute)attribute).MinimumLength;
            }

            return (min, max);
        }
    }
}
