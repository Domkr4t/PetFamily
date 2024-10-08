using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.VO
{
    public record PetDetails
    {
        public string Type { get; private set; } = default!;

        public string Breed { get; private set; } = default!;

        private PetDetails(string type, string breed)
        {
            Type = type;
            Breed = breed;
        }

        public static Result<PetDetails> Create(string type, string breed)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<PetDetails>.Failure("Не введен тип питомца!");

            if (string.IsNullOrWhiteSpace(breed))
                return Result<PetDetails>.Failure("Не введена порода питомца!");

            return new PetDetails(type, breed);

        }
    }
}