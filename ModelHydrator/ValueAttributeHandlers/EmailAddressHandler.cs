using ModelHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelHydrator.ValueAttributeHandlers
{
    public class EmailAddressHandler : IValueAttributeHandler
    {
        public const string MAX_LENGTH_ERROR = "A valid email can't be created with less than 5 charcters";
        public const int MIN_LENGTH = 5;
        public const int DEFAULT_MAX_LENGTH = 40;
        private const string REQUIRED_EMAIL_CHARACTERS = "@.";

        private EnhancedRandom _random;

        public EmailAddressHandler(EnhancedRandom random)
        {
            _random = random;
        }

        public Type HandledAttribute { get; } = typeof(EmailAddressAttribute);

        public object GenerateValidValue(ModelProperty property)
        {
            if (property.Max.HasValue && property.Max.Value < MIN_LENGTH)
                throw new InvalidOperationException(MAX_LENGTH_ERROR);

            if (property.Min.HasValue && property.Min < MIN_LENGTH) property.Min = MIN_LENGTH;

            var generatedCharacterCount = _random.NextDimension(property, MIN_LENGTH, DEFAULT_MAX_LENGTH) 
                                          - REQUIRED_EMAIL_CHARACTERS.Length;

            var partLength = generatedCharacterCount / 3;

            var username = _random.NextString(partLength);
            var domain = _random.NextString(partLength);

            var topLevelDomain = _random.NextString( partLength + (generatedCharacterCount % 3) );

            return $"{username}@{domain}.{topLevelDomain}";
        }
    }
}
