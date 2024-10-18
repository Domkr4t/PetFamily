using PetFamily.Domain.Pets.Enum;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

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

        public Address Address { get; private set; } = default!;

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
                    PetDetails petDetails,
                    string description,
                    string coloring,
                    string petHealthInfo,
                    Address address,
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
            PetDetails = petDetails;
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

        public static Result<Pet, Error> Create(PetId id,
                                         string name,
                                         PetDetails petDetails,
                                         string description,
                                         string coloring,
                                         string petHealthInfo,
                                         Address address,
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
                return Errors.General.ValueIsInvalid("Name");
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                return Errors.General.ValueContainsInvalidCharacters("Name");

            if (petDetails is null)
                return Errors.General.ValueIsInvalid("PetDetails");

            if (string.IsNullOrWhiteSpace(description))
                return Errors.General.ValueIsInvalid("description");

            if (string.IsNullOrWhiteSpace(coloring))
                return Errors.General.ValueIsInvalid("coloring");
            if (!Regex.IsMatch(name, @"^[a-zA-Z-]+$"))
                return Errors.General.ValueContainsInvalidCharacters("coloring");

            if (string.IsNullOrWhiteSpace(petHealthInfo))
                return Errors.General.ValueIsInvalid("petHealthInfo");

            if (address is null)
                return Errors.General.ValueIsInvalid("petHealthInfo");

            if (weight <= 0)
                return Errors.General.ValueIsInvalid("weight");
            if (weight >= 150)
                return Errors.General.ValueIsInvalid("weight");

            if (growth <= 0)
                return Errors.General.ValueIsInvalid("growth");

            if (volunteerTelephone is null)
                return Errors.General.ValueIsInvalid("volunteerTelephone");

            if (bankDetails is null)
                return Errors.General.ValueIsInvalid("bankDetails");

            if (petPhoto is null)
                return Errors.General.ValueIsInvalid("petPhoto");

            var pet = new Pet(id, name, petDetails, description, coloring, petHealthInfo, address,
                              weight, growth, volunteerTelephone, isCastrated, dateOfBirth,
                              isVaccinated, assistanceStatus, bankDetails, petPhoto);

            return Result<Pet, Error>.Success(pet);
        }

    }
}
