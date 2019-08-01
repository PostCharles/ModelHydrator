using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.ValueAttributeHandlers
{
    public class EmailAddressHandler : IValueAttributeHandler
    {
        public Type HandledAttribute { get; } = typeof(EmailAddressAttribute);

        public object GenerateValidValue(ModelProperty property)
        {
            throw new NotImplementedException();
        }
    }
}
