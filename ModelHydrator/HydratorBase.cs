using ModelHydrator.DimensionAttributeHandlers;
using ModelHydrator.ValueAttributeHandlers;
using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator
{
    public class HydratorBase
    {

        private IEnumerable<ModelProperty> _properties;
        public IEnumerable<ModelProperty> Properties
        {
            get { return _properties ?? (_properties = GetProperties()); }
            
        }


        private IEnumerable<IComparisonAttributeHandler> ComparisonHandlers { get { return _handlerCollection.ComparisonAttributeHandlers;  } }
        private IEnumerable<IDimensionAttributeHandler> DimensionHandlers { get { return _handlerCollection.DimensionAttributeHandlers; } }
        private IEnumerable<IValueAttributeHandler> ValueHandlers { get { return _handlerCollection.ValueAttributeHandlers; } }



        private readonly Type _modelType;
        private readonly IHandlerCollection _handlerCollection;
        
        public HydratorBase(Type modelType) : this(modelType, new DefaultHandlerCollection())
        { }

        public HydratorBase(Type modelType, IHandlerCollection handlerCollection)
        {
            _modelType = modelType;
            _handlerCollection = handlerCollection;
        }



        private IEnumerable<ModelProperty> GetProperties()
        {
            var result = new List<ModelProperty>();

            foreach (var propInfo in _modelType.GetProperties())
            {
                if (propInfo.CanWrite)
                {
                    var property = new ModelProperty(_modelType, propInfo);

                    SetPropertyDimension(property);

                    result.Add(property);
                }
            }

            return result;
        }

        private void SetPropertyDimension(ModelProperty property)
        {
            foreach (var handler in DimensionHandlers)
            {
                if (property.HasAttribute(handler.HandledAttribute))
                {
                    var (min, max) = handler.GetDimension( property.GetAttribute(handler.HandledAttribute) );
                    if (min.HasValue) property.Min = min;
                    if (max.HasValue) property.Max = max;
                }
            }
        }

        public object GetInstance()
        {
            var instance = Activator.CreateInstance(_modelType);

            PopultateProperties(instance);

            return instance;
        }

        private void PopultateProperties(object instance)
        {
            foreach (var modelProperty in Properties.Where(p => p.IsRequired) )
            {
                var handler = ValueHandlers.First(h => modelProperty.HasAttribute( h.HandledAttribute ) );
                modelProperty.Property.SetValue(instance, handler.GenerateValue(modelProperty));
            };

        }

    }
}
