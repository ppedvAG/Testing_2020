using System.Collections.Generic;

namespace ppedv.MittagsHunger.Model
{
    public class Lieferant : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Gericht> Gerichte { get; set; } = new HashSet<Gericht>();
        public virtual ICollection<Bestelltag> Bestelltage { get; set; } = new HashSet<Bestelltag>();
    }


}
