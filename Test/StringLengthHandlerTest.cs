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

        public PropertyDimension Dimension { get; }
        public StringLenghtHandler Sut { get; }

        public StringLengthHandlerTest()
        {
            Dimension = new PropertyDimension();
            Sut = new StringLenghtHandler();
        }



        [Fact]
        public void HandledAttribute_Set_StringLengthAttribute()
        {
            var sut = new StringLenghtHandler();

            Assert.Equal(typeof(StringLengthAttribute), sut.HandledAttribute);
        }

        [Fact]
        public void AddDimension_AttributeHasMax_AddsMaxToDimension()
        {
            var attrib = new StringLengthAttribute(TEST_MAX);

            Sut.AddDimension(Dimension, attrib);

            Assert.Equal(attrib.MaximumLength, Dimension.Max);
            
        }

        [Fact]
        public void AddDimension_AttributeMinSet_AddMinToDimension()
        {
            var attrib = new StringLengthAttribute(TEST_MAX) { MinimumLength = TEST_MIN };

            Sut.AddDimension(Dimension, attrib);

            Assert.Equal(attrib.MinimumLength, Dimension.Min);
        }

        [Fact]
        public void AddDimension_AttributeMinIsZero_MinNotAddedToDimension()
        {
            var attrib = new StringLengthAttribute(TEST_MAX);

            Sut.AddDimension(Dimension, attrib);

            Assert.True(attrib.MinimumLength == 0);

            Assert.False(Dimension.HasMin);
        }
    }
}
