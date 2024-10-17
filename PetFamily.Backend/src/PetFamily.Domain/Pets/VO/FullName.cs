using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Pets.VO
{
    public record FullName
    {
        public string Surname { get; }

        public string FirstName { get; }

        public string? Patronymic { get; }

        private FullName(string surname, string firstName, string? patronymic)
        {
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
        }

        public static Result<FullName, Error> Create (string surname, string firstName, string? patronymic)
        {
            if (string.IsNullOrWhiteSpace(surname))
                return Errors.General.ValueIsInvalid("surname");
            if (!Regex.IsMatch(surname, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("surname");

            if (string.IsNullOrWhiteSpace(firstName))
                return Errors.General.ValueIsInvalid("firstName");
            if (!Regex.IsMatch(surname, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("firstName");

            if (patronymic != null)
                if (!Regex.IsMatch(surname, @"^[a-zA-Z-]+$"))
                    return Errors.General.ValueContainsInvalidCharacters("surname");

            var fullName = new FullName(surname, firstName, patronymic);
            
            return fullName;
        }


    }
}
