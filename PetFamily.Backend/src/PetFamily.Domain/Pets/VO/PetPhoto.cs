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

        public static Result<PetPhoto, Error> Create(string path, bool mainOrNot)
        {
            if (string.IsNullOrWhiteSpace(path))
                return Errors.General.ValueIsInvalid("path");
            if (!Regex.IsMatch(path, @"^[a-zA-Z]:\\|\\\\[a-zA-Z0-9_\\-\. ]+$"))
                return Errors.General.ValueContainsInvalidCharacters("path");

            return new PetPhoto(path, mainOrNot);

        }
    }
}
