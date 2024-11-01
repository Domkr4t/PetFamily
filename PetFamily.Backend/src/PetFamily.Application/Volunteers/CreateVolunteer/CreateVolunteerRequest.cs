using PetFamily.Application.Volunteers.Dtos;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(IEnumerable<SocialNetworkDto> SocialNetworkListDto,
                                         IEnumerable<BankDetailsDto> BankDetailsListDto,
                                         FullNameDto FullNameDto,
                                         string Email,
                                         string Description,
                                         int YearsOfExperience,
                                         PhoneNumberDto PhoneNumberDto);
}
