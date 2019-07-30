using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IHandlerCollection
    {
        ICollection<IComparisonAttributeHandler> ComparisonAttributeHandlers { get; }
        ICollection<IDimensionAttributeHandler> DimensionAttributeHandlers { get; }
        ICollection<IValueAttributeHandler> ValueAttributeHandlers { get; }
    }
}
