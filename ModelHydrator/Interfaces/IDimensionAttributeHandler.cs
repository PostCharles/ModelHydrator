using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IDimensionAttributeHandler : IAttributeHandler
    {
        PropertyDimension AddDimension(PropertyDimension size, object attribute);
    }
}
