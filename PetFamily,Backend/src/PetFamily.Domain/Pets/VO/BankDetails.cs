// Ignore Spelling: BIC KPP

using PetFamily.Domain.Shared;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

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
            if (!Regex.IsMatch(bankName, @"^[a-zA-Z-]+$"))
                return Result<BankDetails>.Failure("В названии банка не долно быть цифр и других символов(кроме дефиса)");

            if (string.IsNullOrWhiteSpace(bic))
                return Result<BankDetails>.Failure("Не введен БИК");
            if (!Regex.IsMatch(bic, @"^\d+$"))
                return Result<BankDetails>.Failure("БИК должен содержать только цифры");

            if (string.IsNullOrWhiteSpace(correspondentAccount))
                return Result<BankDetails>.Failure("Не введен корреспонденсткий счет");
            if (correspondentAccount.Length != 20)
                return Result<BankDetails>.Failure("Неправильное количество символов в корреспонденстком счете");
            if (!Regex.IsMatch(correspondentAccount, @"^\d+$"))
                return Result<BankDetails>.Failure("Корреспонденсткий счет должен содержать только цифры");

            if (string.IsNullOrWhiteSpace(kpp))
                return Result<BankDetails>.Failure("Не введен КПП");
            if (kpp.Length != 9)
                return Result<BankDetails>.Failure("Неправильное количество символов в КПП");
            if (!Regex.IsMatch(kpp, @"^\d+$"))
                return Result<BankDetails>.Failure("КПП должен содержать только цифры");

            if (string.IsNullOrWhiteSpace(inn))
                return Result<BankDetails>.Failure("Не введен ИНН");
            if (inn.Length != 10 || inn.Length != 12)
                return Result<BankDetails>.Failure("Неправильное количество символов в ИНН");
            if (!Regex.IsMatch(inn, @"^\d+$"))
                return Result<BankDetails>.Failure("ИНН должен содержать только цифры");

            return new BankDetails(bankName, bic, correspondentAccount, inn, kpp);
        }

    }
}

