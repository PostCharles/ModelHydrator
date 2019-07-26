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

        private readonly Type _modelType;

        public HydratorBase(Type modelType)
        {
            _modelType = modelType;

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
            foreach (var prop in _modelType.GetProperties())
            {
                prop.SetValue(instance, Generate(prop));
            }

        }

        private object Generate(PropertyInfo prop)
        {
            throw new NotImplementedException();
        }

    }
}
