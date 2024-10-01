using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.VO
{
    public record PetPhoto
    {
        public string Path { get; } 

        public bool MainOrNot { get; }


        private PetPhoto(string path, bool mainOrNot)
        {
            Path = path;
            MainOrNot = mainOrNot;
        }

        public static Result<PetPhoto> Create(string path, bool mainOrNot)
        {
            if (string.IsNullOrWhiteSpace(path))
                return Result<PetPhoto>.Failure("Путь не может быть пустым");

            return new PetPhoto(path, mainOrNot);

        }
    }
}
