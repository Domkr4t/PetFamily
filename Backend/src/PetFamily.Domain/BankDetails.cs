﻿// Ignore Spelling: BIC KPP

using CSharpFunctionalExtensions;

namespace PetFamily.Domain
{
    public class BankDetails
    {
        public Guid Id { get; set; }

        public string BankName { get; set; } = default!;

        public string BIC { get; set; } = default!;

        public string CorrespondentAccount { get; set; } = default!;

        public string INN { get; set; } = default!;

        public string KPP { get; set; } = default!;

        //For EF Core
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

            var bankDetails = new BankDetails(bankName, bic, correspondentAccount, inn, kpp);

            return Result.Success(bankDetails);
        }

    }
}

