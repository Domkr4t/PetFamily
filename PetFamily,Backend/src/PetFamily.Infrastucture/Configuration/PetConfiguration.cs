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
                pb.Property(si => si.SpecieId).IsRequired();
                pb.Property(bi => bi.BreedId).IsRequired();
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

            builder.ComplexProperty(a => a.Address, ab =>
            {
                ab.Property(c => c.Country).IsRequired();
                ab.Property(r => r.Region).IsRequired();
                ab.Property(ci => ci.City).IsRequired();
                ab.Property(h => h.House).IsRequired();
                ab.Property(f => f.Flat).IsRequired();
                ab.Property(p => p.PostalCode).IsRequired();
            });

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

            builder.OwnsOne(p => p.PetPhotos, pb =>
            {
                pb.ToJson();

                pb.OwnsMany(pf => pf.PetPhotos, petPhotoBuilder =>
                {
                    petPhotoBuilder.Property(path => path.Path).IsRequired();
                    petPhotoBuilder.Property(mon => mon.MainOrNot).IsRequired();
                });
            });
        }
    }
}
