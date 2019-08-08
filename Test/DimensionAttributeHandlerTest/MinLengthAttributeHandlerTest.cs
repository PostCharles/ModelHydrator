using ModelHydrator.DimensionAttributeHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.DimensionAttributeHandlerTest
{
    public class MinLengthAttributeHandlerTest
    {
        public const int TEST_MIN = 10;

        public MinLengthAttributeHandler Sut { get; }
        public MinLengthAttribute MinLengthAttribute { get; }

        public MinLengthAttributeHandlerTest()
        {
            Sut = new MinLengthAttributeHandler();
            MinLengthAttribute = new MinLengthAttribute(TEST_MIN);
        }
        
        [Fact]
        public void HandledAttribute_ReturnsMinLengthAttribute()
        {
            Assert.Equal(typeof(MinLengthAttribute), Sut.HandledAttribute);
        }

        [Fact]
        public void GetDimension_MinHasValueReturnsTrue()
        {
            var result = Sut.GetDimension(MinLengthAttribute);

            Assert.True(result.Min.HasValue);
        }

        [Fact]
        public void GetDimension_MaxHasValueReturnsFalse()
        {
            var result = Sut.GetDimension(MinLengthAttribute);

            Assert.False(result.Max.HasValue);
        }

        [Fact]
        public void GetDimension_MinValueEqualsAttributeMin()
        {
            var result = Sut.GetDimension(MinLengthAttribute);

            Assert.Equal(MinLengthAttribute.Length, result.Min);
        }
    }
}
