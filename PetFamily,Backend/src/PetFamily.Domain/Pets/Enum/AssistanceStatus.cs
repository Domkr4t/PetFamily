using System.ComponentModel.DataAnnotations;

namespace PetFamily.Domain.Pets.Enum
{
    public enum AssistanceStatus
    {
        [Display(Name = "Нуждается в помощи")]
        NeedHelp = 0,

        [Display(Name = "Ищет дом")]
        LookingHome = 1,

        [Display(Name = "Нашел дом")]
        FoundHouse = 2,
    }
}
