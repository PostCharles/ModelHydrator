using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator.DimensionAttributeHandlers
{
    public class MaxLengthHandler : IDimensionAttributeHandler
    {
        public Type HandledAttribute { get; } = typeof(MaxLengthAttribute);

        public (int? Min, int? Max) GetDimension(ValidationAttribute attribute)
        {
            return (new int?(), ((MaxLengthAttribute)attribute).Length);
        }
    }
}
