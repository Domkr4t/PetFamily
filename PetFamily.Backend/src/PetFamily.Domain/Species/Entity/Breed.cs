using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.VO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Species.Entity
{
    public class Breed : Entity<BreedId>
    {
        public string Name { get; private set; } = default!;

        //For EF Core
        private Breed(BreedId id) : base(id)
        {
            
        }

        private Breed(BreedId id, string name) : base(id)
        {
            Name = name;
        }

        public static Result<Breed, Error> Create (BreedId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsInvalid("name");
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                return Errors.General.ValueContainsInvalidCharacters("name");

            var breed = new Breed(id, name);    

            return Result<Breed, Error>.Success(breed);
        }
    }
}
