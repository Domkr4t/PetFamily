using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.VO
{
    public record PhoneNumber
    {
        public string Value { get; } = default!;


        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static Result<PhoneNumber> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result<PhoneNumber>.Failure("Телефон не может быть пустым");

            return new PhoneNumber(value);
        }
    }
}