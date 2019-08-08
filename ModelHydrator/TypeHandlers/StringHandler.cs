using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator.TypeHandlers
{
    public class StringHandler : ITypeHandler
    {
        private const int DEFAULT_MIN = 1;
        private const int DEFAULT_MAX = 40;

        private readonly EnhancedRandom _random;

        public StringHandler(EnhancedRandom random)
        {
            _random = random;
        }

        public Type HandledType { get; } = typeof(string);

        public object GenerateValue(ModelProperty property)
        {
            var length = _random.NextDimension(property, DEFAULT_MIN, DEFAULT_MAX);
            return _random.NextString(length);
        }

    }
}
