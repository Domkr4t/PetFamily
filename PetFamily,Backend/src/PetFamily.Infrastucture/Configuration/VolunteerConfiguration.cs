using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Pets.VO;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastucture.Configuration
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                   .HasConversion(id => id.Value, value => VolunteerId.Create(value));

            builder.Property(v => v.Surname)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.Property(v => v.FirstName)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.Property(v => v.Patronymic)
                   .IsRequired(false)
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.Property(v => v.Email)
                   .IsRequired()
                   .HasMaxLength(Constants.NAME_LENGTH);

            builder.Property(v => v.Description)
                   .IsRequired()
                   .HasMaxLength(Constants.DESCRIPTION_LENGTH);

            builder.Property(v => v.YearsOfExperience)
                   .IsRequired();

            builder.ComplexProperty(v => v.PhoneNumber, pb =>
            {
                pb.Property(pn => pn.Value).IsRequired();
            });

            //builder.ComplexProperty(v => v.SocialNetworks, sb =>
            //{
                
            //});

            //builder.ComplexProperty(v => v.BankDetails, bb =>
            //{
                
            //});

            builder.HasMany(v => v.Pets)
                   .WithOne()
                   .HasForeignKey("volunteer_id");
        }
    }
}
