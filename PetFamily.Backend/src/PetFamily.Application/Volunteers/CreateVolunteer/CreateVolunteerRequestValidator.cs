using CSharpFunctionalExtensions;
using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Pets.VO;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
    {
        public CreateVolunteerRequestValidator()
        {
            RuleForEach(c => c.SocialNetworkListDto).MustBeValueObject(s => 
                SocialNetwork.Create(s.Name, s.Link));

            RuleForEach(c => c.BankDetailsListDto).MustBeValueObject(b =>
                BankDetails.Create(b.BankName, b.BIC, b.CorrespondentAccount, b.INN, b.KPP));

            RuleFor(c => c.FullNameDto).MustBeValueObject(f => FullName.Create(f.Surname, f.Surname, f.Patronymic));

            RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("Email не правильно заполнен");

            RuleFor(c => c.Description).NotEmpty();

            RuleFor(c => c.YearsOfExperience).NotEmpty().Must(y => y >= 0).WithMessage("Стаж должен быть заполнен и не быть отрицательным");

            RuleFor(c => c.PhoneNumberDto).MustBeValueObject(p => PhoneNumber.Create(p.Value));
        }
    }
}
