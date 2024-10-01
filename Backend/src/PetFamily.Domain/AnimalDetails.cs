using CSharpFunctionalExtensions;

namespace PetFamily.Domain
{
    public class AnimalDetails
    {
        public AnimalDetailsId Id { get; private set; }

        public string Type { get; private set; } = default!;

        public string Breed { get; private set; } = default!;

        //For EF Core
        private AnimalDetails()
        {

        }

        private AnimalDetails(AnimalDetailsId id, string type, string breed)
        {
            Id = id;
            Type = type;
            Breed = breed;
        }

        public static Result<AnimalDetails> Create (AnimalDetailsId id, string type, string breed)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result.Failure<AnimalDetails>("Не введен тип питомца!");

            if (string.IsNullOrWhiteSpace(breed))
                return Result.Failure<AnimalDetails>("Не введена порода питомца!");

            var animalDetails = new AnimalDetails(id, type, breed);

            return Result.Success(animalDetails);
        }
    }
}