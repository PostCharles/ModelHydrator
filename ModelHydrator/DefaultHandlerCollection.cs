using ModelHydrator.ValueAttributeHandlers;
using ModelHydrator.DimensionAttributeHandlers;
using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ModelHydrator.TypeHandlers;

namespace ModelHydrator
{
    public class DefaultHandlerCollection : IHandlerCollection
    {
        public ICollection<IComparisonAttributeHandler> ComparisonAttributeHandlers { get; }
        public ICollection<IDimensionAttributeHandler> DimensionAttributeHandlers { get; }
        public ICollection<IValueAttributeHandler> ValueAttributeHandlers { get; }
        public ICollection<ITypeHandler> TypeHandlers { get; }

        public DefaultHandlerCollection()
        {
            var rand = new EnhancedRandom(DateTime.Now.Millisecond);

            ComparisonAttributeHandlers = new List<IComparisonAttributeHandler>
            {
               
            };

            DimensionAttributeHandlers = new List<IDimensionAttributeHandler>
            {
                new StringLenghtHandler()
            };

            ValueAttributeHandlers = new List<IValueAttributeHandler>
            {
                new EmailAddressHandler(rand)
            };

            TypeHandlers = new List<ITypeHandler>
            {
                new StringHandler(rand)
            };
        }
    }
}
