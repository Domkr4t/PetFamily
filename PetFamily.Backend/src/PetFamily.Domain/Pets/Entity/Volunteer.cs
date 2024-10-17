using PetFamily.Domain.Pets.Enum;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.Entity
{
    public class Volunteer : Entity<VolunteerId>
    {
        private readonly List<Pet> _pets = [];
        private readonly List<SocialNetwork> _socialNetworks = [];
        private readonly List<BankDetails> _bankDetails = [];

        public FullName FullName { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int YearsOfExperience { get; private set; }

        public int AnimalsFoundHomes => _pets.Count(x => x.AssistanceStatus == AssistanceStatus.FoundHouse);

        public int AnimalsNotFoundHomes => _pets.Count(x => x.AssistanceStatus == AssistanceStatus.LookingHome);

        public int AnimalsNeedHelp => _pets.Count(x => x.AssistanceStatus == AssistanceStatus.NeedHelp);

        public PhoneNumber PhoneNumber { get; private set; } = default!;

        public SocialNetworkList SocialNetworks { get; private set; } = default!;

        public BankDetailsList BankDetails { get; private set; } = default!;

        public IReadOnlyList<Pet> Pets => _pets;

        //For EF Core
        private Volunteer(VolunteerId id) : base(id)
        {

        }

        private Volunteer(VolunteerId id,
                          SocialNetworkList socialNetworks,
                          BankDetailsList bankDetails,
                          FullName fullName,
                          string email,
                          string description,
                          int yearsOfExperience,
                          PhoneNumber phoneNumber) : base(id)
        {
            SocialNetworks = socialNetworks;
            BankDetails = bankDetails;
            FullName = fullName;
            Email = email;
            Description = description;
            YearsOfExperience = yearsOfExperience;
            PhoneNumber = phoneNumber;
        }

        public static Result<Volunteer, Error> Create(VolunteerId id, 
                                               SocialNetworkList socialNetworks,
                                               BankDetailsList bankDetails,
                                               FullName fullName,
                                               string email,
                                               string description,
                                               int yearsOfExperience,
                                               PhoneNumber phoneNumber)
        {
            if (socialNetworks == null)
                return Errors.General.ValueIsInvalid("socialNetworks");

            if (bankDetails == null)
                return Errors.General.ValueIsInvalid("bankDetails");

            if (fullName == null)
                return Errors.General.ValueIsInvalid("fullName");

            if (string.IsNullOrWhiteSpace(email))
                return Errors.General.ValueIsInvalid("email");
            if (!email.Contains('@') && email.Contains('.'))
                return Errors.General.ValueContainsInvalidCharacters("email");

            if (string.IsNullOrWhiteSpace(description))
                return Errors.General.ValueIsInvalid("description");

            if (yearsOfExperience < 0)
                return Errors.General.ValueIsInvalid("yearsOfExperience");

            if (phoneNumber == null)
                return Errors.General.ValueIsInvalid("phoneNumber");


            var volunteer = new Volunteer(id, socialNetworks, bankDetails, fullName, email, description, yearsOfExperience, phoneNumber);

            return Result<Volunteer, Error>.Success(volunteer);
        }
    }
}
