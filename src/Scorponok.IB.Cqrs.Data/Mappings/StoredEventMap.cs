using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Cqrs.Data.Mappings
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.Data)
                .HasColumnName("Data")
                .HasColumnType("ntext");

            builder.Property(c => c.User)
                .HasColumnName("User")
                .HasColumnType("nvarchar(100)");

            builder.Property(c => c.MessageType)
                .HasColumnName("MessageType");

            builder.Property(c => c.AggregateId)
                .HasColumnName("AggregateId");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}