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

        public string Surname { get; private set; } = default!;

        public string FirstName { get; private set; } = default!;

        public string? Patronymic { get; private set; }

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

        private Volunteer(List<Pet> pets,
                          SocialNetworkList socialNetworks,
                          BankDetailsList bankDetails,
                          VolunteerId id,
                          string surname,
                          string firstName,
                          string? patronymic,
                          string email,
                          string description,
                          int yearsOfExperience,
                          PhoneNumber phoneNumber) : base(id)
        {
            _pets = pets;
            SocialNetworks = socialNetworks;
            BankDetails = bankDetails;
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
            Email = email;
            Description = description;
            YearsOfExperience = yearsOfExperience;
            PhoneNumber = phoneNumber;
        }

        public static Result<Volunteer> Create(List<Pet> pets,
                                               SocialNetworkList socialNetworks,
                                               BankDetailsList bankDetails,
                                               VolunteerId id,
                                               string surname,
                                               string firstName,
                                               string? patronymic,
                                               string email,
                                               string description,
                                               int yearsOfExperience,
                                               PhoneNumber phoneNumber)
        {

            if (pets == null)
                return Result<Volunteer>.Failure("К волонтеру не прикреплены питомцы!");

            if (socialNetworks == null)
                return Result<Volunteer>.Failure("Не введены социальные сети!");

            if (bankDetails == null)
                return Result<Volunteer>.Failure("Не введены банковские реквизиты!");

            if (string.IsNullOrWhiteSpace(surname))
                return Result<Volunteer>.Failure("Не введена фамилия!");

            if (string.IsNullOrWhiteSpace(firstName))
                return Result<Volunteer>.Failure("Не введено имя!");

            if (string.IsNullOrWhiteSpace(email))
                return Result<Volunteer>.Failure("Не введен email!");

            if (string.IsNullOrWhiteSpace(description))
                return Result<Volunteer>.Failure("Не введено описание!");

            if (yearsOfExperience <= 0)
                return Result<Volunteer>.Failure("Не правильно введен стаж!");

            if (phoneNumber == null)
                return Result<Volunteer>.Failure("Не введен номер телефона!");


            var volunteer = new Volunteer(pets, socialNetworks, bankDetails, id, surname,
                                          firstName, patronymic, email, description, yearsOfExperience, phoneNumber);

            return Result<Volunteer>.Success(volunteer);
        }
    }
}
