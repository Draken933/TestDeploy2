using Microsoft.EntityFrameworkCore;

namespace SampleAppApi.Models
{
    public class EntryContext : DbContext
    {
        public EntryContext(DbContextOptions<EntryContext> options)
            : base(options)
        {
        }

        public DbSet<EntryItem> EntryItems { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder.UseNpgsql("Host = entwicklungsdaten.postgres.database.azure.com; Database=postgres;Username=jan @entwicklungsdaten; Password=TischBecherMäher8;SslMode=Require");
            //=> optionsBuilder.UseNpgsql("Host=entwicklungsdaten.postgres.database.azure.com;Database=postgres;Username=jan@entwicklungsdaten;Password=TischBecherMäher8;Ssl Mode=Require");
        //=> optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Legion_MongoDB41");
    }
}