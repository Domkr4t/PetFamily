using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Pets.VO
{
    public record PetPhoto
    {
        public string Path { get; } = default!;

        public bool MainOrNot { get; }

        private PetPhoto()
        {
            
        }

        private PetPhoto(string path, bool mainOrNot)
        {
            Path = path;
            MainOrNot = mainOrNot;
        }

        public static Result<PetPhoto> Create(string path, bool mainOrNot)
        {
            if (string.IsNullOrWhiteSpace(path))
                return Result<PetPhoto>.Failure("Путь не может быть пустым");
            if (!Regex.IsMatch(path, @"^[a-zA-Z]:\\|\\\\[a-zA-Z0-9_\\-\. ]+$"))
                return Result<PetPhoto>.Failure("Путь неправильно введен");

            return new PetPhoto(path, mainOrNot);

        }
    }
}
