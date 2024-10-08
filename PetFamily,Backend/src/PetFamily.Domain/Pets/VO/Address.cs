using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Pets.VO
{
    public record Address
    {
        public string Country { get; }

        public string Region { get; }

        public string City { get; }

        public string House { get; }

        public string Flat { get; }
        
        public string PostalCode { get; }

        private Address(string country, string region, string city, string house, string flat, string postalCode)
        {
            Country = country;
            Region = region;
            City = city;
            House = house;
            Flat = flat;
            PostalCode = postalCode;
        }

        public static Result<Address> Create (string country, string region, string city, string house, string flat, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Result<Address>.Failure("Не введена страна");
            if (!Regex.IsMatch(country, @"^[a-zA-Z-]+$"))
                return Result<Address>.Failure("В названии страны не долно быть цифр и других символов(кроме дефиса)");

            if (string.IsNullOrWhiteSpace(region))
                return Result<Address>.Failure("Не введена область");
            if (!Regex.IsMatch(region, @"^[a-zA-Z-]+$"))
                return Result<Address>.Failure("В названии области не долно быть цифр и других символов(кроме дефиса)");

            if (string.IsNullOrWhiteSpace(city))
                return Result<Address>.Failure("Не введен город");
            if (!Regex.IsMatch(city, @"^[a-zA-Z-]+$"))
                return Result<Address>.Failure("В названии города не долно быть цифр и других символов(кроме дефиса)");

            if (string.IsNullOrWhiteSpace(house))
                return Result<Address>.Failure("Не введен номер дома");

            if (string.IsNullOrWhiteSpace(flat))
                return Result<Address>.Failure("Не введена квартира");
            if (!Regex.IsMatch(flat, @"^\d+$"))
                return Result<Address>.Failure("В номере квартиры должны быть только цифры");

            if (string.IsNullOrWhiteSpace(postalCode))
                return Result<Address>.Failure("Не введен почтовый индекс");
            if (!Regex.IsMatch(postalCode, @"^\d+$"))
                return Result<Address>.Failure("В номере почтового индекса должны быть только цифры");

            return new Address(country, region, city, house, flat, postalCode); 
        }



    }
}
