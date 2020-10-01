using ppedv.MittagsHunger.Model;
using System.Data.Entity;

namespace ppedv.MittagsHunger.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Bestelltag> Bestelltage { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Gericht> Gerichte { get; set; }
        public DbSet<Lieferant> Lieferanten { get; set; }
        public DbSet<Person> Personen { get; set; }
    }
}
