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
        private IEnumerable<ComparisonMap> _comparisonMappings;
        private IEnumerable<GeneratorMap> _generatorMappings;

        private IEnumerable<ModelProperty> Properties
        {
            get { return _properties ?? (_properties = GetProperties()); }
        }

        private IEnumerable<ComparisonMap> ComparisonMappings
        {
            get { return _comparisonMappings ?? (_comparisonMappings = GetComparisonMappings()); }
            
        }

        private IEnumerable<GeneratorMap> GeneratorMappings
        {
            get { return _generatorMappings ?? (_generatorMappings = GetGeneratorMappings()); }
        }



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

                    property = SetPropertyDimension(property);

                    result.Add(property);
                }
            }

            return result;
        }

        private ModelProperty SetPropertyDimension(ModelProperty property)
        {
            foreach (var handler in _handlerCollection.DimensionAttributeHandlers)
            {
                if (property.HasAttribute(handler.HandledAttribute))
                {
                    var (min, max) = handler.GetDimension( property.GetAttribute(handler.HandledAttribute) );
                    if (min.HasValue) property.Min = min;
                    if (max.HasValue) property.Max = max;
                }
            }

            return property;
        }

        private IEnumerable<ComparisonMap> GetComparisonMappings()
        {
            var result = new List<ComparisonMap>();

            foreach (var property in Properties)
            {
                var handler = _handlerCollection.ComparisonAttributeHandlers
                              .FirstOrDefault(h => property.HasAttribute(h.HandledAttribute));

                if (handler != null) result.Add( new ComparisonMap(property, handler) );
            }

            return result;
        }

        private IEnumerable<GeneratorMap> GetGeneratorMappings()
        {
            var result = new List<GeneratorMap>();

            foreach (var property in Properties.Where(p => p.IsRequired) )
            {

                var handler = _handlerCollection.ValueAttributeHandlers
                               .FirstOrDefault(h => property.HasAttribute(h.HandledAttribute));

                if (handler != null) result.Add( new GeneratorMap(property, handler.GenerateValidValue) );
                else 
                {
                    var typeHandler = _handlerCollection.TypeHandlers
                                      .FirstOrDefault(h => h.HandledType == property.PropertyInfo.PropertyType);

                    if (typeHandler != null) result.Add(new GeneratorMap(property, typeHandler.GenerateValue) );
                }
            }

            return result;
        }

 


        public object GetInstance()
        {
            var instance = Activator.CreateInstance(_modelType);

            foreach (var map in GeneratorMappings)
            {
                instance = map.SetValueOnInstance(instance);
            }
            foreach (var map in ComparisonMappings)
            {
                instance = map.SetValueOnInstance(instance);
            }

            return instance;
        }

    }
}
