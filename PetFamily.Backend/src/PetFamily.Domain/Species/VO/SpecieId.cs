namespace PetFamily.Domain.Species.VO
{
    public record SpecieId
    {
        public Guid Value { get; }

        private SpecieId(Guid value)
        {
            Value = value;
        }

        public static SpecieId NewSpeciesId() => new(Guid.NewGuid());

        public static SpecieId EmptySpeciesId() => new(Guid.Empty);

        public static SpecieId Create(Guid id) => new(id);
    }
}
