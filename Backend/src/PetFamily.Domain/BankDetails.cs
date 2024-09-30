// Ignore Spelling: BIC KPP

using CSharpFunctionalExtensions;

namespace PetFamily.Domain
{
    public class BankDetails
    {
        public BankDetailsId Id { get; private set; }

        public string BankName { get; private set; } = default!;

        public string BIC { get; private set; } = default!;

        public string CorrespondentAccount { get; private set; } = default!;

        public string INN { get; private set; } = default!;

        public string KPP { get; private set; } = default!;

        //For EF Core
        private BankDetails() 
        {
            
        }

        private BankDetails(BankDetailsId id, string bankName, string bic, string correspondentAccount, string inn, string kpp)
        {
            Id = id;
            BankName = bankName;
            BIC = bic;
            CorrespondentAccount = correspondentAccount;
            INN = inn;
            KPP = kpp;
        }

        public static Result<BankDetails> Create(BankDetailsId id, string bankName, string bic, string correspondentAccount, string inn, string kpp)
        {
            if (string.IsNullOrWhiteSpace(bankName))
                return Result.Failure<BankDetails>("Не введено название банка");

            if (string.IsNullOrWhiteSpace(bic))
                return Result.Failure<BankDetails>("Не введен БИК");

            if (string.IsNullOrWhiteSpace(correspondentAccount))
                return Result.Failure<BankDetails>("Не введен корреспонденсткий счет");

            if (kpp.Length != 20)
                return Result.Failure<BankDetails>("Неправильное количество символов в корреспонденстком счете");

            if (string.IsNullOrWhiteSpace(inn))
                return Result.Failure<BankDetails>("Не введен ИНН");
            
            if (inn.Length != 10 || inn.Length != 12)
                return Result.Failure<BankDetails>("Неправильное количество символов в ИНН");

            if (string.IsNullOrWhiteSpace(kpp))
                return Result.Failure<BankDetails>("Не введен КПП");

            if (kpp.Length != 9)
                return Result.Failure<BankDetails>("Неправильное количество символов в КПП");

            var bankDetails = new BankDetails(id, bankName, bic, correspondentAccount, inn, kpp);

            return Result.Success(bankDetails);
        }

    }
}

