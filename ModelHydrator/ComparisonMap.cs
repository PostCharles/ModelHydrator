using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator
{
    internal class ComparisonMap
    {
        public ComparisonMap(ModelProperty property, IComparisonAttributeHandler handler)
        {
            Property = property;
            Handler = handler;
        }
        public ModelProperty Property { get; }
        public IComparisonAttributeHandler Handler { get; }

        public object SetValueOnInstance(object instance)
        {
            var value = Handler.GetComparisonValue(Property, instance);
            Property.SetValue(instance, value);

            return instance;
        }
    }
}
