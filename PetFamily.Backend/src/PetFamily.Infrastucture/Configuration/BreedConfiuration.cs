using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.Entity;
using PetFamily.Domain.Species.VO;

namespace PetFamily.Infrastucture.Configuration
{
    public class BreedConfiuration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("breeds");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasConversion(id => id.Value, value => BreedId.Create(value));

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);
        }
    }
}
