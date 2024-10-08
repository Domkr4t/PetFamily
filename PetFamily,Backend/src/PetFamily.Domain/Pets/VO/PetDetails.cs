using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.VO;

namespace PetFamily.Domain.Pets.VO
{
    public record PetDetails
    {
        public Guid SpecieId { get; }

        public Guid BreedId { get; }

        private PetDetails(Guid specieId, Guid breedId)
        {
            SpecieId = specieId;
            BreedId = breedId;  
        }

        public static Result<PetDetails> Create(Guid specieId, Guid SbreedId) 
                      => new PetDetails(specieId, breedId);
    }
}