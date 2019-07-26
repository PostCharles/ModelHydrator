using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHydrator.Interfaces
{
    public interface IAttributeHandler
    {
        Type HandledAttribute { get; }
    }
}
