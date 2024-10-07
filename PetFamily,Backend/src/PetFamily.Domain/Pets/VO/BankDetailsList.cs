namespace PetFamily.Domain.Pets.VO
{
    public record BankDetailsList
    {
        public IReadOnlyList<BankDetails> BankDetails { get; }

        private BankDetailsList()
        {
            
        }


        public BankDetailsList(List<BankDetails> bankDetails)
        {
            BankDetails = bankDetails;
        }
    }
}
