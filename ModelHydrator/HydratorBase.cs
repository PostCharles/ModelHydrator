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

        public object GetInstance()
        {
            var instance = Activator.CreateInstance(_modelType);

            return instance;
        }
    }
}
