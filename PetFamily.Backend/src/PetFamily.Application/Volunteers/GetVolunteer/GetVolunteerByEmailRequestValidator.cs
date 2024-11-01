using FluentValidation;

namespace PetFamily.Application.Volunteers.GetVolunteer
{
    public class GetVolunteerByEmailRequestValidator : AbstractValidator<GetVolunteerByEmailRequest>
    {
        public GetVolunteerByEmailRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
