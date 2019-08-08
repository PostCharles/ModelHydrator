using ModelHydrator;
using ModelHydrator.DimensionAttributeHandlers;
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


        private StringLenghtHandler Sut { get; }

        private StringLengthAttribute StringLengthAttributeWithMaxValue { get; }
        private StringLengthAttribute StringLengthAttributeWithMinAndMaxValues { get; }

        public StringLengthHandlerTest()
        {
            Sut = new StringLenghtHandler();

            StringLengthAttributeWithMaxValue = new StringLengthAttribute(TEST_MAX); ;
            StringLengthAttributeWithMinAndMaxValues = new StringLengthAttribute(TEST_MAX)
                                                           { MinimumLength = TEST_MIN };
        }

        [Fact]
        public void HandledAttribute_ReturnsStringLengthAttribute()
        {
            Assert.Equal(typeof(StringLengthAttribute), Sut.HandledAttribute);
        }

        [Fact]
        public void GetDimension_AttributeWithMaxLength_MaxHasValueTrue()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMaxValue);

            Assert.True(result.Max.HasValue);
        }

        [Fact]
        public void GetDimension_AttributeWithMaxLength_MinHasValueFalse()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMaxValue);

            Assert.False(result.Min.HasValue);
        }

        [Fact]
        public void GetDimension_AttributeWithMaxLength_MaxEqualsAttributeMax()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMaxValue);

            Assert.Equal(result.Max.Value, StringLengthAttributeWithMaxValue.MaximumLength);
        }

        [Fact]
        public void GetDimension_AttributeWithMinAndMaxLength_MinHasValueTrue()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMinAndMaxValues);

            Assert.True(result.Min.HasValue);
        }

        [Fact]
        public void GetDimension_AttributeWithMinAndMaxLength_MaxHasValueTrue()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMinAndMaxValues);

            Assert.True(result.Max.HasValue);
        }

        [Fact]
        public void GetDimension_AttributeWithMinAndMaxLength_MinValueEqualsAttributeMin()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMinAndMaxValues);

            Assert.Equal(result.Min.Value, StringLengthAttributeWithMinAndMaxValues.MinimumLength);
        }

        [Fact]
        public void GetDimension_AttributeWithMinAndMaxLength_MaxValueEqualsAttributeMax()
        {
            var result = Sut.GetDimension(StringLengthAttributeWithMinAndMaxValues);

            Assert.Equal(result.Max.Value, StringLengthAttributeWithMinAndMaxValues.MaximumLength);
        }
    }
}
