using CSharpFunctionalExtensions;

namespace PetFamily.Domain
{
    public class Volunteer
    {
        private readonly List<Pet> _pets = [];
        private readonly List<SocialNetwork> _socialNetworks = [];
        private readonly List<BankDetails> _bankDetails = [];

        public Guid Id { get; private set; }

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

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

        public IReadOnlyList<BankDetails> BankDetails => _bankDetails;

        public IReadOnlyList<Pet> Pets => _pets;

        //For EF Core
        private Volunteer()
        {

        }

        private Volunteer(List<Pet> pets,
                          List<SocialNetwork> socialNetworks,
                          List<BankDetails> bankDetails,
                          Guid id,
                          string surname,
                          string firstName,
                          string? patronymic,
                          string email,
                          string description, 
                          int yearsOfExperience, 
                          PhoneNumber phoneNumber)
        {
            _pets = pets;
            _socialNetworks = socialNetworks;
            _bankDetails = bankDetails;
            Id = id;
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
            Email = email;
            Description = description;
            YearsOfExperience = yearsOfExperience;
            PhoneNumber = phoneNumber;
        }

        public static Result<Volunteer> Create(List<Pet> pets, 
                                               List<SocialNetwork> socialNetworks, 
                                               List<BankDetails> bankDetails, 
                                               Guid id,
                                               string surname, 
                                               string firstName, 
                                               string? patronymic,
                                               string email,
                                               string description, 
                                               int yearsOfExperience, 
                                               PhoneNumber phoneNumber)
        {

            if (pets == null)
                return Result.Failure<Volunteer>("К волонтеру не прикреплены питомцы!");

            if (socialNetworks == null)
                return Result.Failure<Volunteer>("Не введены социальные сети!");

            if (bankDetails == null)
                return Result.Failure<Volunteer>("Не введены банковские реквизиты!");

            if (string.IsNullOrWhiteSpace(surname))
                return Result.Failure<Volunteer>("Не введена фамилия!");
            
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<Volunteer>("Не введено имя!");

            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Volunteer>("Не введен email!");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Volunteer>("Не введено описание!");

            if (yearsOfExperience <= 0)
                return Result.Failure<Volunteer>("Не правильно введен стаж!");

            if (phoneNumber == null)
                return Result.Failure<Volunteer>("Не введен номер телефона!");


            var volunteer = new Volunteer(pets, socialNetworks, bankDetails, id, surname, 
                                          firstName, patronymic, email, description, yearsOfExperience, phoneNumber);

            return Result.Success(volunteer);
        }
    }
}
