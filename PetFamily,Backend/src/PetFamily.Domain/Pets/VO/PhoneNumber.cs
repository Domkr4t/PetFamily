using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

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
            if (Regex.IsMatch(value, @"^(\+7|8)?\s?(\(?\d{3}\)?|\d{3})[\s.-]?(\d{3}[\s.-]?\d{2}|\d{2}[\s.-]?\d{3})$"))
                return Result<PhoneNumber>.Failure("Телефон неправильно введен");
            #region Описание проверки телефона
            //Этот паттерн соответствует следующим форматам:
            //+7(123) 456 - 78 - 90
            //8 912 345 67 89
            //987 654 3210
            #endregion

            return new PhoneNumber(value);
        }
    }
}