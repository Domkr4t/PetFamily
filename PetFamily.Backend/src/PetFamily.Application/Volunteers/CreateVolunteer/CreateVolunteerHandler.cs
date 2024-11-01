using FluentValidation;
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

        public async Task<Result<Guid, Error>> Handle(
            CreateVolunteerRequest request,
            CancellationToken cancellationToken = default)
        {
            var volunteerId = VolunteerId.NewVolunteerId();

            var socialNetworks = request.SocialNetworkListDto
                .Select(s => SocialNetwork.Create(s.Name, s.Link).Value);

            var socialNetworksList = new SocialNetworkList(socialNetworks.ToList());


            var bankDetails = request.BankDetailsListDto
                .Select(b => BankDetails.Create(b.BankName, b.BIC, b.CorrespondentAccount, b.INN, b.KPP).Value);

            var bankDetailsList = new BankDetailsList(bankDetails.ToList());

            var fullName = FullName.Create(request.FullNameDto.FirstName,
                                           request.FullNameDto.Surname,
                                           request.FullNameDto.Patronymic).Value;

            var phoneNumber = PhoneNumber.Create(request.PhoneNumberDto.Value).Value;

            var volunteerResult = Volunteer.Create(volunteerId,
                                             socialNetworksList,
                                             bankDetailsList,
                                             fullName,
                                             request.Email,
                                             request.Description,
                                             request.YearsOfExperience,
                                             phoneNumber);

            if (volunteerResult.IsFailure)
                return Errors.General.ValueIsInvalid("volunteerResult");

            var volunteer = volunteerResult.Value;

            await _volunteersRepository.Add(volunteer, cancellationToken);

            return volunteer.Id.Value;
        }
    }
}
