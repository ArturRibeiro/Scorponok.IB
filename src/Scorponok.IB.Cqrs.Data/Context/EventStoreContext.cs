using Microsoft.EntityFrameworkCore;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Cqrs.Data.Mappings;

namespace Scorponok.IB.Cqrs.Data.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        public EventStoreContext(DbContextOptions<EventStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // get the configuration from the app settings
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    // define the database to use
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}

    }
}