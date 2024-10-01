using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastucture.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(id => id.Value, value => PetId.Create(value));

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.ComplexProperty(p => p.PetDetails, pb =>
            {
                pb.Property(pd => pd.Type).IsRequired();
                pb.Property(pd => pd.Breed).IsRequired();
            });
        
            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(Constants.DESCRIPTION_LENGTH);

            builder.Property(p => p.Coloring)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.Property(p => p.PetHealthInfo)
                   .IsRequired()
                   .HasMaxLength(Constants.DESCRIPTION_LENGTH);

            builder.Property(p => p.Address)
                   .IsRequired()
                   .HasMaxLength(Constants.ADDRESS_LENGTH);

            builder.Property(p => p.Weight)
                   .IsRequired();

            builder.Property(p => p.Growth)
                   .IsRequired();

            builder.ComplexProperty(p => p.VolunteerTelephone, vb =>
            {
                vb.Property(vt => vt.Value).IsRequired();
            });

            builder.Property(p => p.IsCastrated)
                   .IsRequired();

            builder.Property(p => p.DateOfBirth)
                   .IsRequired();

            builder.Property(p => p.IsVaccinated)
                   .IsRequired();

            builder.Property(p => p.AssistanceStatus)
                   .IsRequired();

            builder.ComplexProperty(p => p.BankDetails, bb =>
            {

            });

            builder.ComplexProperty(p => p.PetPhotos, pb =>
            {

            });
        }
    }
}
