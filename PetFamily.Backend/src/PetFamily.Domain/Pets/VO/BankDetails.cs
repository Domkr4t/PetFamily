// Ignore Spelling: BIC KPP

using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Pets.VO
{
    public class BankDetails
    {
        public string BankName { get; } = default!;

        public string BIC { get; } = default!;

        public string CorrespondentAccount { get; } = default!;

        public string INN { get; } = default!;

        public string KPP { get; } = default!;

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

        public static Result<BankDetails, Error> Create(string bankName, string bic, string correspondentAccount, string inn, string kpp)
        {
            if (string.IsNullOrWhiteSpace(bankName))
                return Errors.General.ValueIsInvalid("bankName");
            if (!Regex.IsMatch(bankName, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("bankName");

            if (string.IsNullOrWhiteSpace(bic))
                return Errors.General.ValueIsInvalid("bic");
            if (!Regex.IsMatch(bic, @"^\d+$"))
                return Errors.General.ValueContainsInvalidCharacters("bic");

            if (string.IsNullOrWhiteSpace(correspondentAccount))
                return Errors.General.ValueIsInvalid("correspondentAccount");
            if (correspondentAccount.Length != 20)
                return Errors.General.ValueIsInvalid("correspondentAccount");
            if (!Regex.IsMatch(correspondentAccount, @"^\d+$"))
                return Errors.General.ValueContainsInvalidCharacters("correspondentAccount"); 

            if (string.IsNullOrWhiteSpace(kpp))
                return Errors.General.ValueIsInvalid("kpp");
            if (kpp.Length != 9)
                return Errors.General.ValueIsInvalid("kpp");
            if (!Regex.IsMatch(kpp, @"^\d+$"))
                return Errors.General.ValueContainsInvalidCharacters("kpp");

            if (string.IsNullOrWhiteSpace(inn))
                return Errors.General.ValueIsInvalid("inn");
            if (inn.Length != 10 & inn.Length != 12)
                return Errors.General.ValueIsInvalid("inn");
            if (!Regex.IsMatch(inn, @"^\d+$"))
                return Errors.General.ValueContainsInvalidCharacters("inn");

            return new BankDetails(bankName, bic, correspondentAccount, inn, kpp);
        }

    }
}

