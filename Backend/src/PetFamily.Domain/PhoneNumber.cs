using CSharpFunctionalExtensions;
using System.Runtime.InteropServices.Marshalling;

namespace PetFamily.Domain
{
    public record PhoneNumber
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static Result<PhoneNumber> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<PhoneNumber>("Телефон не может быть пустым");

            return new PhoneNumber(value);  
        }
    }
}