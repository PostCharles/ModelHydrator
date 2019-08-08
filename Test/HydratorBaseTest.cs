using ModelHydrator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Test
{

    public class HydratorBaseTest
    {
        [Fact]
        public void GetInstance_StringLength_PopulatedProperty()
        {
            var hydrator = new HydratorBase(typeof(TestModel));
            var model = (TestModel)hydrator.GetInstance();

            Assert.InRange(model.TextField.Length, TestModel.USERNAME_MIN, TestModel.USERNAME_MAX);
        }
    }

    public class TestModel
    {
        public const int USERNAME_MAX = 10;
        public const int USERNAME_MIN = 5;

        [StringLength(USERNAME_MAX, MinimumLength = USERNAME_MIN)]
        public string TextField { get; set; }

        [EmailAddress]
        public string Empty { get; set; }
    }
}