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
    public class MaxLengthAttributeHandlerTest
    {
        public const int TEST_MAX = 10;

        public MaxLengthAttributeHandler Sut { get; }
        public MaxLengthAttribute MaxLengthAttribute { get; }

        public MaxLengthAttributeHandlerTest()
        {
            Sut = new MaxLengthAttributeHandler();
            MaxLengthAttribute = new MaxLengthAttribute(TEST_MAX);
        }

        [Fact]
        public void HandledAttribute_ReturnsMaxLengthAttribute()
        {
            Assert.Equal(typeof(MaxLengthAttribute), Sut.HandledAttribute);
        }

        [Fact]
        public void GetDimension_MaxHasValueReturnsTrue()
        {
            var result = Sut.GetDimension(MaxLengthAttribute);

            Assert.True(result.Max.HasValue);
        }

        [Fact]
        public void GetDimension_MinHasValueReturnsFalse()
        {
            var result = Sut.GetDimension(MaxLengthAttribute);

            Assert.False(result.Min.HasValue);
        }

        [Fact]
        public void GetDimension_MaxValueEqualsAttributeMax()
        {
            var result = Sut.GetDimension(MaxLengthAttribute);

            Assert.Equal(MaxLengthAttribute.Length, result.Max);
        }
    }
}
