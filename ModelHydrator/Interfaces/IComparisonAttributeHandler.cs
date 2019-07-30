using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IComparisonAttributeHandler : IAttributeHandler
    {
        object GetComparisonValue(object instance, ModelProperty property);
    }
}
