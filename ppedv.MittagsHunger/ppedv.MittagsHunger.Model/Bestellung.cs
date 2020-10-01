namespace ppedv.MittagsHunger.Model
{
    public class Bestellung : Entity
    {
        public Bestelltag Bestelltag { get; set; }
        public virtual Person Person { get; set; }
        public virtual Gericht Gericht { get; set; }
    }


}
