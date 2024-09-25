namespace PetFamily.Domain
{
    public class Volunteer
    {
        public Guid Id { get; set; }

        public BankDetails BankDetails { get; set; } = default!;
    }
}
