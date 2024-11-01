using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.GetVolunteer
{
    public class GetVolunteerByEmailHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;

        public GetVolunteerByEmailHandler(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }

        public async Task<Result<Volunteer, Error>> Handle(
            GetVolunteerByEmailRequest request,
            CancellationToken cancellationToken)
        {
            var volunteer = await _volunteersRepository.GetByEmail(request.Email, cancellationToken);

            if (volunteer.IsFailure)
                return Errors.General.VolunteerNotFoundByEmail("Volunteer", request.Email);

            return volunteer;
        }
    }
}
