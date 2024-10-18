using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.VO;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Species.Entity
{
    public class Specie : Entity<SpecieId>
    {
        private readonly List<Breed> _breeds = [];

        public string Name { get; private set; } = default!;

        public IReadOnlyList<Breed> Breeds => _breeds;

        //For EF Core
        private Specie(SpecieId id) : base(id)
        {
            
        }

        private Specie(SpecieId id, string name, List<Breed> breeds) : base(id)
        {
            Name = name;
            _breeds = breeds;
        }

        public static Result<Specie, Error> Create(SpecieId id, string name, List<Breed> breeds)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsInvalid("name");
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                return Errors.General.ValueContainsInvalidCharacters("name");

            if (breeds is null)
                return Errors.General.ValueIsInvalid("breeds");

            var species = new Specie(id, name, breeds);

            return Result<Specie, Error>.Success(species);
        }


    }
}
