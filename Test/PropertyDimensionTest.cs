using ModelHydrator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class PropertyDimensionTest
    {
        [Fact]
        public void SetMin_WithValue_SetsMinToValue()
        {
            var sut = new PropertyDimension();
            int testValue = 5;

            sut.SetMin(testValue);

            Assert.Equal(testValue, sut.Min);
        }

        [Fact]
        public void SetMin_WithValue_SetsHasMinToTrue()
        {
            var sut = new PropertyDimension();

            Assert.False(sut.HasMin);

            sut.SetMin(1);

            Assert.True(sut.HasMin);
        }

        [Fact]
        public void SetMax_WithValue_SetsMaxToValue()
        {
            var sut = new PropertyDimension();
            int testValue = 5;

            sut.SetMax(testValue);

            Assert.Equal(testValue, sut.Max);
        }

        [Fact]
        public void SetMax_WithValue_SetsHasMaxToTrue()
        {
            var sut = new PropertyDimension();

            Assert.False(sut.HasMax);

            sut.SetMax(1);

            Assert.True(sut.HasMax);
        }
    }
}
