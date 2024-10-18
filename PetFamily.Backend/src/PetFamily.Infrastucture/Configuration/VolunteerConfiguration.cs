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

            builder.ComplexProperty(f => f.FullName, fb =>
            {
                fb.Property(s => s.Surname).IsRequired().HasMaxLength(Constants.NAME_LENGTH);
                fb.Property(fn => fn.FirstName).IsRequired().HasMaxLength(Constants.NAME_LENGTH);
                fb.Property(p => p.Patronymic).IsRequired(false).HasMaxLength(Constants.NAME_LENGTH);
            });


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

            builder.OwnsOne(v => v.SocialNetworks, sb =>
            {
                sb.ToJson();

                sb.OwnsMany(f => f.Networks, nb =>
                {
                    nb.Property(n => n.Name).IsRequired();
                    nb.Property(l => l.Link).IsRequired();
                });
            });

            builder.OwnsOne(v => v.BankDetails, bb =>
            {
                bb.ToJson();

                bb.OwnsMany(b => b.BankDetails, bBuilder =>
                {
                    bBuilder.Property(bn => bn.BankName).IsRequired();
                    bBuilder.Property(bic => bic.BIC).IsRequired();
                    bBuilder.Property(ca => ca.CorrespondentAccount).IsRequired();
                    bBuilder.Property(inn => inn.INN).IsRequired();
                    bBuilder.Property(kpp => kpp.KPP).IsRequired();
                });
            });

            builder.HasMany(v => v.Pets)
                   .WithOne()
                   .HasForeignKey("volunteer_id");
        }
    }
}
