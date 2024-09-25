namespace PetFamily.Domain
{
    public class AnimalDetails
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = default!;

        public string Breed { get; set; } = default!;
    }
}