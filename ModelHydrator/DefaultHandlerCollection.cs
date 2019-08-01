using ModelHydrator.ValueAttributeHandlers;
using ModelHydrator.DimensionAttributeHandlers;
using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            ComparisonAttributeHandlers = new List<IComparisonAttributeHandler>
            {
               
            };

            DimensionAttributeHandlers = new List<IDimensionAttributeHandler>
            {
                new StringLenghtHandler()
            };

            ValueAttributeHandlers = new List<IValueAttributeHandler>
            {
                new EmailAddressHandler()
            };

            TypeHandlers = new List<ITypeHandler>
            {

            };
        }
    }
}
