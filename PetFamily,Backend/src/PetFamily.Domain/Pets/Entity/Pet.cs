﻿using PetFamily.Domain.Pets.Enum;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.Entity
{
    public class Pet : Entity<PetId>
    {
        private readonly List<BankDetails> _bankDetails = [];
        private readonly List<PetPhoto> _petPhotos = [];

        public string Name { get; private set; } = default!;

        public PetDetails PetDetails { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string Coloring { get; private set; } = default!;

        public string PetHealthInfo { get; private set; } = default!;

        public string Address { get; private set; } = default!;

        public int Weight { get; private set; }

        public int Growth { get; private set; }

        public PhoneNumber VolunteerTelephone { get; private set; } = default!;

        public bool IsCastrated { get; private set; }

        public DateOnly DateOfBirth { get; private set; } = default!;

        public bool IsVaccinated { get; private set; }

        public AssistanceStatus AssistanceStatus { get; private set; } = default!;

        public BankDetailsList BankDetails { get; private set; } = default!;

        public PetPhotoList PetPhotos { get; private set; } = default!;

        //For EF Core
        private Pet(PetId id) : base(id)
        {

        }

        private Pet(PetId id,
                    string name,
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
                    BankDetailsList bankDetails,
                    PetPhotoList petPhotos) : base(id)
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
            BankDetails = bankDetails;
            PetPhotos = petPhotos;
        }

        public static Result<Pet> Create(PetId id,
                                         string name,
                                         PetDetails animalDetails,
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
                                         BankDetailsList bankDetails,
                                         PetPhotoList petPhoto)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Pet>.Failure("У питомца должно быть имя!");

            if (animalDetails is null)
                return Result<Pet>.Failure("У питомца должна быть информация о виде и породе!");

            if (string.IsNullOrWhiteSpace(description))
                return Result<Pet>.Failure("У питомца должно быть описание!");

            if (string.IsNullOrWhiteSpace(description))
                return Result<Pet>.Failure("У питомца должно быть описание!");

            if (string.IsNullOrWhiteSpace(coloring))
                return Result<Pet>.Failure("У питомца должен быть окрас!");

            if (string.IsNullOrWhiteSpace(petHealthInfo))
                return Result<Pet>.Failure("У питомца должна быть информация о состоянии здоровья!");

            if (string.IsNullOrWhiteSpace(address))
                return Result<Pet>.Failure("У питомца должен быть адрес!");

            if (weight <= 0)
                return Result<Pet>.Failure("Вес не может быть меньше или равен нулю!");

            if (growth <= 0)
                return Result<Pet>.Failure("Рост не может быть меньше или равен нулю!");

            if (volunteerTelephone is null)
                return Result<Pet>.Failure("Не прикреплен телефон волонтера!");

            if (bankDetails is null)
                return Result<Pet>.Failure("Не прикреплены банковские реквизиты для помощи питомцу!");

            if (petPhoto is null)
                return Result<Pet>.Failure("Не прикреплены фотографии питомца!");

            var pet = new Pet(id, name, description, coloring, petHealthInfo, address,
                              weight, growth, volunteerTelephone, isCastrated, dateOfBirth,
                              isVaccinated, assistanceStatus, bankDetails, petPhoto);

            return Result<Pet>.Success(pet);
        }

    }
}
