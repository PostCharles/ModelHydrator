using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IDimensionAttributeHandler : IAttributeHandler
    {
        (int? Min, int? Max) GetDimension(ModelProperty property);
    }
}
