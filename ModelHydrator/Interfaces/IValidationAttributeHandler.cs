using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IValidationAttributeHandler : IAttributeHandler
    {
        object Generate(PropertyDimension dimension, object validationAttribute, object[] attributes);
    }
}
