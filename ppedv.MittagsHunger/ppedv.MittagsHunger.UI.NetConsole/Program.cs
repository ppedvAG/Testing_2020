using ppedv.MittagsHunger.BusinessLogic;
using ppedv.MittagsHunger.Model;
using System;
using System.Text;

namespace ppedv.MittagsHunger.UI.NetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** MittagsHunger v0.1 GOLD EDITION ***");
            Console.OutputEncoding = Encoding.UTF8;

            var core = new Core(new Data.EF.EfRepository()); //todo DI

            foreach (var liefer in core.Repository.GetAll<Lieferant>())
            {
                Console.WriteLine($"{liefer.Name}");
                foreach (var g in liefer.Gerichte)
                {
                    Console.WriteLine($"\t{g.Name} {g.KCal}KCal {g.Preis:c} {(g.Vegetarisch ? "🥦" : "🍖")}");
                }
            }


            Console.WriteLine($"Lieferant mit most KCAL: {core.GetLieferantWithMostKCal().Name}");
            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
