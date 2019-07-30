using ModelHydrator;
using ModelHydrator.DimensionAttributeHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class StringLengthHandlerTest
    {
        public const int TEST_MIN = 5;
        public const int TEST_MAX = 100;

        public ModelProperty Property { get; }
        public StringLenghtHandler Sut { get; }

        public StringLengthHandlerTest()
        {
            Property = new ModelProperty(null, null);
            Sut = new StringLenghtHandler();
        }

    }
}
