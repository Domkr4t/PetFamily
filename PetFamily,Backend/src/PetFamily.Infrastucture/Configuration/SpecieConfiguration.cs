using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.Entity;
using PetFamily.Domain.Species.VO;

namespace PetFamily.Infrastucture.Configuration
{
    public class SpecieConfiguration : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            builder.ToTable("species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .HasConversion(id => id.Value, value => SpecieId.Create(value));

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.HasMany(b => b.Breeds)
                   .WithOne()
                   .HasForeignKey("specie_id");
        }
    }
}
