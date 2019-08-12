using ModelHydrator;
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
    public class EmailAddressHandlerTest
    {
        public EmailAddressHandler Sut { get; }

        public EmailAddressHandlerTest()
        {
            Sut = new EmailAddressHandler(new EnhancedRandom());
        }

        [Fact]
        public void HandledAttribute_ReturnsEmailAddressAttribute()
        {
            Assert.Equal(typeof(EmailAddressAttribute), Sut.HandledAttribute);
        }

    }
}
