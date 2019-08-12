using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator.ValueAttributeHandlers
{
    public class PhoneHandler : IValueAttributeHandler
    {
        public Type HandledAttribute { get; } = typeof(PhoneAttribute);

        public object GenerateValidValue(ModelProperty property)
        {
            throw new NotImplementedException();
        }
    }
}
