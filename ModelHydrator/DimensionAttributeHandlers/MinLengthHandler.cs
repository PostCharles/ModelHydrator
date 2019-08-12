using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.DimensionAttributeHandlers
{
    public class MinLengthHandler : IDimensionAttributeHandler
    {

        public Type HandledAttribute { get; } = typeof(MinLengthAttribute);

        public (int? Min, int? Max) GetDimension(ValidationAttribute attribute)
        {
            return ( ((MinLengthAttribute)attribute).Length , new int?() );
        }
    }
}
