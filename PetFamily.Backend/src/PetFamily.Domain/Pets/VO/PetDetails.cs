﻿using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.VO;

namespace PetFamily.Domain.Pets.VO
{
    public record PetDetails
    {
        public SpecieId SpecieId { get; } = default!;

        public Guid BreedId { get; }

        private PetDetails() 
        { 
            
        }

        private PetDetails(SpecieId specieId, Guid breedId)
        {
            SpecieId = specieId;
            BreedId = breedId;  
        }

        public static Result<PetDetails, Error> Create(SpecieId specieId, Guid breedId) 
                      => new PetDetails(specieId, breedId);
    }
}