using CSharpFunctionalExtensions;
using System.Reflection.Metadata.Ecma335;

namespace PetFamily.Domain
{
    public record SocialNetwork 
    {
        public string Name { get; }

        public string Link { get; }

        private SocialNetwork(string name, string link)
        {
            Name = name;
            Link = link;
        }
        
        public static Result<SocialNetwork> Create (string name, string link)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<SocialNetwork>("Название социальной сети не может быть пустым");

            if (string.IsNullOrWhiteSpace(link))
                return Result.Failure<SocialNetwork>("Ссылка не может быть пустой");

            return new SocialNetwork(name, link);
        }
    }
}
