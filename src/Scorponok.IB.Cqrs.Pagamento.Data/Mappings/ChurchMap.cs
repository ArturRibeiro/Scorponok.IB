using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.IB.Domain.Models.Churchs;

namespace Scorponok.IB.Cqrs.Data.Mappings
{
	public class ChurchMap : IEntityTypeConfiguration<Church>
	{
		public void Configure(EntityTypeBuilder<Church> builder)
		{
			builder.HasKey(x => x.Id);

			builder
				.Property(c => c.Name)
				.HasColumnName("Name")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(c => c.Photo)
				.HasMaxLength(100)
				.HasColumnName("Photo")
				.IsRequired();

			#region Mapping complex - Email
			builder
				.OwnsOne(p => p.Email)
				.Property(p => p.Value)
				.HasColumnName("Email")
				.IsRequired();

			builder
				.OwnsOne(p => p.Email)
				.Ignore(p => p.Mensagem);

			builder
				.OwnsOne(p => p.Email)
				.Ignore(p => p.Valido);
			#endregion

			#region Mapping complex - Telephone
			builder
				.OwnsOne(p => p.MobileTelephone)
				.Ignore(p => p.Region);

			builder
				.OwnsOne(p => p.MobileTelephone)
				.Ignore(p => p.Prefix);

			builder
				.OwnsOne(p => p.MobileTelephone)
				.Property(p => p.Number)
				.HasColumnName("PhoneMobile")
				.IsRequired();

			builder
				.OwnsOne(p => p.MobileTelephone)
				.Ignore(x => x.Mensagem);

			builder
				.OwnsOne(p => p.MobileTelephone)
				.Ignore(x => x.Valido);
			#endregion

			#region Mapping complex - FixedTelephone
			builder
				.OwnsOne(p => p.TelephoneFixed)
				.Ignore(p => p.Region);

			builder
				.OwnsOne(p => p.TelephoneFixed)
				.Ignore(p => p.Prefix);

			builder
				.OwnsOne(p => p.TelephoneFixed)
				.Property(p => p.Number)
				.HasColumnName("PhoneFixed");

			builder
				.OwnsOne(p => p.TelephoneFixed)
				.Ignore(x => x.Mensagem);

			builder
				.OwnsOne(p => p.TelephoneFixed)
				.Ignore(x => x.Valido);
			#endregion

			builder
				.Ignore(x => x.Address);

		}
	}
}