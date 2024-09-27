﻿using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace PetFamily.Domain
{
    public class Pet
    {
        private readonly List<BankDetails> _bankDetails = [];

        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;

        public AnimalDetails AnimalDetails { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string Coloring { get; private set; } = default!;

        public string PetHealthInfo { get; private set; } = default!;

        public string Address { get; private set; } = default!;

        public int Weight { get; private set; }

        public int Growth { get; private set; }

        public PhoneNumber VolunteerTelephone { get; private set; } = default!;

        public bool IsCastrated { get; private set; }

        public DateOnly DateOfBirth { get; private set; }

        public bool IsVaccinated { get; private set; }

        public AssistanceStatus AssistanceStatus { get; private set; }

        public IReadOnlyList<BankDetails> BankDetails => _bankDetails;

        //For EF Core
        private Pet()
        {

        }

        private Pet(string name, 
                    string description, 
                    string coloring, 
                    string petHealthInfo, 
                    string address, 
                    int weight, 
                    int growth, 
                    PhoneNumber volunteerTelephone, 
                    bool isCastrated, 
                    DateOnly dateOfBirth, 
                    bool isVaccinated, 
                    AssistanceStatus assistanceStatus, 
                    List<BankDetails> bankDetails)
        {
            Name = name;
            Description = description;
            Coloring = coloring;
            PetHealthInfo = petHealthInfo;
            Address = address;
            Weight = weight;
            Growth = growth;
            VolunteerTelephone = volunteerTelephone;
            IsCastrated = isCastrated;
            DateOfBirth = dateOfBirth;
            IsVaccinated = isVaccinated;
            AssistanceStatus = assistanceStatus;
            _bankDetails = bankDetails;
        }

        public static Result<Pet> Create (string name, 
                                          AnimalDetails animalDetails, 
                                          string description, 
                                          string coloring, 
                                          string petHealthInfo, 
                                          string address, 
                                          int weight, 
                                          int growth, 
                                          PhoneNumber volunteerTelephone, 
                                          bool isCastrated,
                                          DateOnly dateOfBirth, 
                                          bool isVaccinated, 
                                          AssistanceStatus assistanceStatus, 
                                          List<BankDetails> bankDetails) 
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Pet>("У питомца должно быть имя!");

            if (animalDetails is null)
                return Result.Failure<Pet>("У питомца должна быть информация о виде и породе!");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Pet>("У питомца должно быть описание!");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Pet>("У питомца должно быть описание!");

            if (string.IsNullOrWhiteSpace(coloring))
                return Result.Failure<Pet>("У питомца должен быть окрас!");

            if (string.IsNullOrWhiteSpace(petHealthInfo))
                return Result.Failure<Pet>("У питомца должна быть информация о состоянии здоровья!");

            if (string.IsNullOrWhiteSpace(address))
                return Result.Failure<Pet>("У питомца должен быть адрес!");

            if (weight <= 0)
                return Result.Failure<Pet>("Вес не может быть меньше или равен нулю!");

            if (growth <= 0)
                return Result.Failure<Pet>("Рост не может быть меньше или равен нулю!");

            if (volunteerTelephone is null)
                return Result.Failure<Pet>("Не прикреплен телефон волонтера!");

            if (bankDetails is null)
                return Result.Failure<Pet>("Не прикреплены банковские реквизиты для помощи питомцу!");

            var pet = new Pet(name, description, coloring, petHealthInfo, address, 
                              weight, growth, volunteerTelephone, isCastrated, dateOfBirth, 
                              isVaccinated, assistanceStatus, bankDetails);

            return Result.Success(pet);
        }

    }

    public enum AssistanceStatus
    {
        [Display(Name = "Нуждается в помощи")]
        NeedHelp = 0,

        [Display(Name = "Ищет дом")]
        LookingHome = 1,

        [Display(Name = "Нашел дом")]
        FoundHouse = 2,
    }
}
