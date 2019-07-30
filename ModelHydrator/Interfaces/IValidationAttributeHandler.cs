using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IValidationAttributeHandler : IAttributeHandler
    {
        object Generate(ModelProperty property);
    }
}
