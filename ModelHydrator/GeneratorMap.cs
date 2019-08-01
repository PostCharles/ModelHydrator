using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator
{
    public class GeneratorMap
    {
        public GeneratorMap(ModelProperty property, Func<ModelProperty,object> generateValue)
        {
            Property = property;
            GenerateValue = generateValue;
        }
        public ModelProperty Property { get; }
        public Func<ModelProperty,object> GenerateValue { get; }

        public object SetValueOnInstance(object instance)
        {
            var generatedValue = GenerateValue(Property);
            Property.SetValue(instance, GenerateValue);

            return instance;
        }
    }
}
