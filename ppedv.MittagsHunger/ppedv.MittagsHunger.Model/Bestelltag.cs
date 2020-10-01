using System;
using System.Collections.Generic;

namespace ppedv.MittagsHunger.Model
{
    public class Bestelltag : Entity
    {
        public DateTime Datum { get; set; } = DateTime.Now;
        public virtual Lieferant Lieferant { get; set; }
        public virtual ICollection<Bestellung> Bestellungen { get; set; } = new HashSet<Bestellung>();

    }


}
