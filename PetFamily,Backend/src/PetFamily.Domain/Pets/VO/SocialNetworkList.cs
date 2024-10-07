namespace PetFamily.Domain.Pets.VO
{
    public record SocialNetworkList
    {
        public IReadOnlyList<SocialNetwork> Networks { get; }

        private SocialNetworkList()
        {

        }

        public SocialNetworkList(List<SocialNetwork> networks)
        {
            Networks = networks;
        }
    }
}
