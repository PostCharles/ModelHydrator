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


        private readonly Type _modelType;
        private readonly PropertyDimensionService _dimensionService;

        public HydratorBase(Type modelType)
        {
            _modelType = modelType;
        }

        private IEnumerable<ModelProperty> GetProperties()
        {
            var result = new List<ModelProperty>();

            foreach (var propInfo in _modelType.GetProperties())
            {
                var property = new ModelProperty(_modelType, propInfo);

                SetPropertyDimension(property);

                result.Add( property );
            }

            return result;
        }

        private void SetPropertyDimension(ModelProperty property)
        {
            var handlers = GetHandlers<IDimensionAttributeHandler>();

            foreach (var handler in handlers)
            {
                if (property.HasAttribute(handler.HandledAttribute))
                {
                    var (min, max) = handler.GetDimension(property);
                    property.Min = min;
                    property.Max = max;
                }
            }
        }

        private List<T> GetHandlers<T>()
        {
            var result = new List<T>();

            var handlerTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableFrom(typeof(T)));

            foreach (var type in handlerTypes) result.Add( (T)Activator.CreateInstance(type) );

            return result;
        
        }



        public object GetInstance()
        {
            var instance = Activator.CreateInstance(_modelType);

            PopultateProperties(instance);

            return instance;
        }

        private void PopultateProperties(object instance)
        {
            foreach (var prop in Properties)
            {
                
            }

        }

    }
}
