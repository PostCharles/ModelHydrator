using ModelHydrator;
using ModelHydrator.ValueAttributeHandlers;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Test.ValueAttributeHandlerTest
{
    public class EmailAddressHandlerTest : IDisposable
    {
        private const string EMAIL_REGEX_PATTERN =  @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";

        private ModelProperty _emailModelProperty;
        public ModelProperty EmailModelProperty
        {
            get { return _emailModelProperty ?? (_emailModelProperty = new ModelProperty(typeof(InvalidEmailModel), typeof(InvalidEmailModel).GetProperty("Email")));  }
            set { _emailModelProperty = value; }
        }


        public Mock<EnhancedRandom> Random { get; }
        public EmailAddressHandler Sut { get; set; }


        public EmailAddressHandlerTest()
        {
            Random = Random ?? new Mock<EnhancedRandom>();
            Sut = Sut ?? new EmailAddressHandler(Random.Object);
        }
        public void Dispose()
        {
            Random.Reset();
            EmailModelProperty = null;
        }



        [Fact]
        public void HandledAttribute_ReturnsEmailAddressAttribute()
        {
            Assert.Equal(typeof(EmailAddressAttribute), Sut.HandledAttribute);
        }

        [Fact]
        public void GenerateValidValue_ModelPropertyMaxLessThanMinLength_ThrowInvalidOperationException()
        {
            
            EmailModelProperty.Max = EmailAddressHandler.MIN_LENGTH - 1;

            Assert.Throws<InvalidOperationException>(() =>
            {
               Sut.GenerateValidValue(EmailModelProperty);
            });
        }

        [Fact]
        public void GenerateValidValue_ModelPropertyMinLessThanDefaultMin_SetModelPropertyMinToMinLength()
        {
            EmailModelProperty.Min = EmailAddressHandler.MIN_LENGTH - 1;

            Sut.GenerateValidValue(EmailModelProperty);

            Assert.Equal(EmailModelProperty.Min, EmailAddressHandler.MIN_LENGTH);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        [InlineData(30)]
        public void GenerateValidValue_GivenRandomReturnLength_ResultValueOfEqualLength(int length)
        {
            var realRandom = new EnhancedRandom();

            Random.Setup(r => r.NextDimension(It.IsAny<ModelProperty>(), It.IsAny<int>(), It.IsAny<int>())).Returns(length);
            Random.Setup(r => r.NextString( It.IsAny<int>() )).Returns((int i) => realRandom.NextString(i));

            var result = (string)Sut.GenerateValidValue(EmailModelProperty);

            Assert.Equal(length, result.Length);
        }

        [Fact]
        public void GenerateValidValue_GivenRandomReturnLength_ReturnsValidResult()
        {
            Sut = new EmailAddressHandler(new EnhancedRandom());

            var result = (string)Sut.GenerateValidValue(EmailModelProperty);

            RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            var regex = new Regex(EMAIL_REGEX_PATTERN, options);

            Assert.Matches(regex,result);
        }
        
    }

    public class InvalidEmailModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
