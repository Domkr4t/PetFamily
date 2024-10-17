using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Pets.VO
{
    public record PhoneNumber
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static Result<PhoneNumber, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsInvalid("value");
            if (Regex.IsMatch(value, @"^(\+7|8)?\s?(\(?\d{3}\)?|\d{3})[\s.-]?(\d{3}[\s.-]?\d{2}|\d{2}[\s.-]?\d{3})$"))
                return Errors.General.ValueContainsInvalidCharacters("value");

            return new PhoneNumber(value);
        }
    }
}