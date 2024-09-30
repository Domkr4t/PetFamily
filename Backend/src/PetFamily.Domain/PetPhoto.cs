namespace PetFamily.Domain
{
    public class PetPhoto
    {
        public Guid Id { get; set; }

        public string Path { get; set; } = default!;

        public bool MainOrNot { get; set; }
    }
}
