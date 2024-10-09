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

        public static Result<SocialNetwork> Create(string name, string link)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<SocialNetwork>.Failure("Название социальной сети не может быть пустым");

            if (string.IsNullOrWhiteSpace(link))
                return Result<SocialNetwork>.Failure("Ссылка не может быть пустой");
            if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
                return Result<SocialNetwork>.Failure("Сcылка неправильно введена");

                return new SocialNetwork(name, link);
        }
    }
}
