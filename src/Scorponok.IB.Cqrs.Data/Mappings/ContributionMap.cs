using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.IB.Domain.Models.Contributions;

namespace Scorponok.IB.Cqrs.Data.Mappings
{
    public class ContributionMap : IEntityTypeConfiguration<Contribution>
    {
        public void Configure(EntityTypeBuilder<Contribution> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("ContributionId");

            builder
                .Property(c => c.Value)
                .HasColumnName("Value")
                .IsRequired();

            builder
                .Property(c => c.Registered)
                .HasColumnName("Registered")
                .IsRequired();

            builder.HasOne(x => x.Member)
                .WithMany(x => x.Contributions)
                .HasForeignKey("MemberId")
                .IsRequired();

            builder
                .Property(c => c.DeliveryDate)
                .HasColumnName("DeliveryDate")
                .IsRequired();

            builder
                .Property(c => c.TypeContribution)
                .HasColumnName("TypeContribution")
                .IsRequired();

        }
    }
}