using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator.Interfaces
{
    public interface ITypeHandler
    {
        Type HandledType { get; }

        object GenerateValue(ModelProperty property);
    }
}
