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

        public static Result<Address, Error> Create (string country, string region, string city, string house, string flat, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Errors.General.ValueIsInvalid("country");
            if (!Regex.IsMatch(country, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("country");

            if (string.IsNullOrWhiteSpace(region))
                return Errors.General.ValueIsInvalid("region");
            if (!Regex.IsMatch(region, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("region");

            if (string.IsNullOrWhiteSpace(city))
                return Errors.General.ValueIsInvalid("city");
            if (!Regex.IsMatch(city, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("city");

            if (string.IsNullOrWhiteSpace(house))
                return Errors.General.ValueIsInvalid("house");

            if (string.IsNullOrWhiteSpace(flat))
                return Errors.General.ValueIsInvalid("flat");
            if (!Regex.IsMatch(flat, @"^\d+$"))
                return Errors.General.ValueContainsInvalidCharacters("flat");

            if (string.IsNullOrWhiteSpace(postalCode))
                return Errors.General.ValueIsInvalid("postalCode");
            if (!Regex.IsMatch(postalCode, @"^\d+$"))
                return Errors.General.ValueContainsInvalidCharacters("postalCode");

            return new Address(country, region, city, house, flat, postalCode); 
        }



    }
}
