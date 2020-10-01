using ppedv.MittagsHunger.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ppedv.MittagsHunger.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Bestelltag> Bestelltage { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Gericht> Gerichte { get; set; }
        public DbSet<Lieferant> Lieferanten { get; set; }
        public DbSet<Person> Personen { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext():this("Server=(localdb)\\mssqllocaldb;Database=MittagsHunger_dev;Trusted_Connection=true")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
