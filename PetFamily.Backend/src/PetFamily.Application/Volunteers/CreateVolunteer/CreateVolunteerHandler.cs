using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;


namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;

        public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }

        public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken = default)
        {

            var volunteerId = VolunteerId.NewVolunteerId();


            var socialNetworks = request.SocialNetworkListDto
                .Select(s => SocialNetwork.Create(s.Name, s.Link));
            if (socialNetworks.First().IsFailure)
                return Errors.General.ValueIsInvalid("socialNetworks", socialNetworks.First().Error.Message);

            var socialNetworksList = new SocialNetworkList(socialNetworks.Select(x => x.Value).ToList());
            if (socialNetworksList is null)
                return Errors.General.ValueIsInvalid("socialNetworksList");


            var bankDetails = request.BankDetailsListDto
                .Select(b => BankDetails.Create(b.BankName, b.BIC, b.CorrespondentAccount, b.INN, b.KPP));
            if (bankDetails.First().IsFailure)
            {
                return Errors.General.ValueIsInvalid("bankDetails", bankDetails.First().Error.Message);
            }

            var bankDetailsList = new BankDetailsList(bankDetails.Select(x => x.Value).ToList()) ;
            if (bankDetailsList is null)
                return Errors.General.ValueIsInvalid("bankDetailsList");


            var fullName = FullName.Create(request.FullNameDto.FirstName,
                                           request.FullNameDto.Surname,
                                           request.FullNameDto.Patronymic);
            if (fullName.IsFailure)
                return Errors.General.ValueIsInvalid("fullName");

            var phoneNumber = PhoneNumber.Create(request.PhoneNumberDto.Value);
            if (phoneNumber.IsFailure)
                return Errors.General.ValueIsInvalid("phoneNumber");

            var volunteerResult = Volunteer.Create(volunteerId, 
                                             socialNetworksList,
                                             bankDetailsList, 
                                             fullName.Value,
                                             request.Email,
                                             request.Description,
                                             request.YearsOfExperience,
                                             phoneNumber.Value);

            if (volunteerResult.IsFailure)
                return Errors.General.ValueIsInvalid("volunteerResult");

            var volunteer = volunteerResult.Value;

            await _volunteersRepository.Add(volunteer, cancellationToken);

            return volunteer.Id.Value;
        }
    }
}
