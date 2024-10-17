namespace PetFamily.Application.Volunteers.Dtos
{
    public record BankDetailsDto (string BankName, 
                                  string BIC, 
                                  string CorrespondentAccount, 
                                  string INN,
                                  string KPP);
}
