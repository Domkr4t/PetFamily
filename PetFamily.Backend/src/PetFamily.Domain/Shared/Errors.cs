namespace PetFamily.Domain.Shared
{
    public static class Errors
    {
        public static class General
        {
            public static Error ValueIsInvalid(string? name = null, string? extraName = null)
            {
                string label = name[..1].ToUpper() + name[1..] ?? "Value";
                string extraLabel = extraName == null ? string.Empty : $". {extraName[..1].ToUpper() + extraName[1..]}";

                return Error.Validation("value.is.invalid", $"{label} is invalid{extraLabel}");
            }

            public static Error NotFound(string? name = null, Guid? id = null)
            {

                string label = name[..1].ToUpper() + name[1..] ?? "Value";
                string forId = id == null ? "" : $" for id: {id}";

                return Error.Validation("record.not.found", $"{label} not found{forId}");
            }

            public static Error ValueIsRequired(string? name = null)
            {

                string label = name[..1].ToUpper() + name[1..] ?? "Value";

                return Error.Validation("value.length.is.invalid", $"{label} length is invalid");
            }

            public static Error ValueContainsInvalidCharacters(string? name = null)
            {

                string label = name[..1].ToUpper() + name[1..] ?? "Value";

                return Error.Validation("value.contains.invalid.characters", $"{label} contains invalid characters");
            }
        }
    }
}
