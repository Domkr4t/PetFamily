namespace PetFamily.Domain
{
    public record AnimalDetailsId
    {
        public Guid Value { get; }

        private AnimalDetailsId(Guid value) 
        {
            Value = value;
        }

        public static AnimalDetailsId NewAnimalDetailsId() => new(Guid.NewGuid());

        public static AnimalDetailsId EmptyAnimalDetailsId() => new(Guid.Empty);
    }
}