using PetFamily.Application.Volunteers.Dtos;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(List<SocialNetworkDto> SocialNetworkListDto,
                                         List<BankDetailsDto> BankDetailsListDto,
                                         FullNameDto FullNameDto,
                                         string Email,
                                         string Description,
                                         int YearsOfExperience,
                                         PhoneNumberDto PhoneNumberDto);

}
