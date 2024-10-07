// Ignore Spelling: BIC KPP

using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.VO
{
    public class BankDetails
    {
        public string BankName { get; private set; } = default!;

        public string BIC { get; private set; } = default!;

        public string CorrespondentAccount { get; private set; } = default!;

        public string INN { get; private set; } = default!;

        public string KPP { get; private set; } = default!;

        private BankDetails()
        {
            
        }

        private BankDetails(string bankName, string bic, string correspondentAccount, string inn, string kpp)
        {
            BankName = bankName;
            BIC = bic;
            CorrespondentAccount = correspondentAccount;
            INN = inn;
            KPP = kpp;
        }

        public static Result<BankDetails> Create(string bankName, string bic, string correspondentAccount, string inn, string kpp)
        {
            if (string.IsNullOrWhiteSpace(bankName))
                return Result<BankDetails>.Failure("Не введено название банка");

            if (string.IsNullOrWhiteSpace(bic))
                return Result<BankDetails>.Failure("Не введен БИК");

            if (string.IsNullOrWhiteSpace(correspondentAccount))
                return Result<BankDetails>.Failure("Не введен корреспонденсткий счет");

            if (kpp.Length != 20)
                return Result<BankDetails>.Failure("Неправильное количество символов в корреспонденстком счете");

            if (string.IsNullOrWhiteSpace(inn))
                return Result<BankDetails>.Failure("Не введен ИНН");

            if (inn.Length != 10 || inn.Length != 12)
                return Result<BankDetails>.Failure("Неправильное количество символов в ИНН");

            if (string.IsNullOrWhiteSpace(kpp))
                return Result<BankDetails>.Failure("Не введен КПП");

            if (kpp.Length != 9)
                return Result<BankDetails>.Failure("Неправильное количество символов в КПП");

            return new BankDetails(bankName, bic, correspondentAccount, inn, kpp);
        }

    }
}

