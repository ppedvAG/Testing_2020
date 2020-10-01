namespace ppedv.MittagsHunger.Model
{
    public class Gericht : Entity
    {
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public int KCal { get; set; }
        public bool Vegetarisch { get; set; }
        public virtual Lieferant Lieferant { get; set; }
    }


}
