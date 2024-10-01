// Ignore Spelling: BIC KPP

namespace PetFamily.Domain
{
    public record BankDetailsId
    {
        public Guid Value { get; }

        private BankDetailsId(Guid value)
        {
            Value = value;
        }

        public static BankDetailsId NewBankDetailsId() => new(Guid.NewGuid());

        public static BankDetailsId EmptyBankDetailsId() => new(Guid.Empty);
    }
}

