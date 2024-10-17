using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.VO
{
    public record SocialNetwork
    { 
        public string Name { get; } = default!;

        public string Link { get; } = default!;

        private SocialNetwork() 
        {
            
        }

        private SocialNetwork(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public static Result<SocialNetwork, Error> Create(string name, string link)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsInvalid("name");

            if (string.IsNullOrWhiteSpace(link))
                return Errors.General.ValueIsInvalid("link");
            if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
                return Errors.General.ValueContainsInvalidCharacters("link");

            return new SocialNetwork(name, link);
        }
    }
}
