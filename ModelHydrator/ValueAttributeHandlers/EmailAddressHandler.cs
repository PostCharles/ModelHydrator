using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.ValueAttributeHandlers
{
    public class EmailAddressHandler : IValueAttributeHandler
    {
        private const int DEFAULT_MIN = 5;
        private const int DEFAULT_MAX = 40;
        private const string REQUIRED_EMAIL_CHARACTERS = "@.";

        private EnhancedRandom _random;

        public EmailAddressHandler(EnhancedRandom random)
        {
            _random = random;
        }

        public Type HandledAttribute { get; } = typeof(EmailAddressAttribute);

        public object GenerateValidValue(ModelProperty property)
        {
            var generatedCharacterCount = _random.NextDimension(property, DEFAULT_MIN, DEFAULT_MAX) 
                                          - REQUIRED_EMAIL_CHARACTERS.Length;

            var partLength = generatedCharacterCount / 3;

            var username = _random.NextString(partLength);
            var domain = _random.NextString(partLength);

            var topLevelDomain = _random.NextString( partLength + (generatedCharacterCount % 3) );

            return $"{username}@{domain}.{topLevelDomain}";
        }
    }
}
