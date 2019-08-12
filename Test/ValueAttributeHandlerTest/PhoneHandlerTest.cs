using ModelHydrator.ValueAttributeHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.ValueAttributeHandlerTest
{
    public class PhoneHandlerTest
    {
        public PhoneHandler Sut { get; }
        public PhoneHandlerTest()
        {
            Sut = new PhoneHandler();
        }

        [Fact]
        public void HandledAttribute_ReturnsPhoneAttribute()
        {
            Assert.Equal(typeof(PhoneAttribute), Sut.HandledAttribute);
        }


    }
}
