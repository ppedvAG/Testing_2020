using Autofac;
using ppedv.MittagsHunger.BusinessLogic;
using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.Model.Contracts;
using System;
using System.Reflection;
using System.Text;

namespace ppedv.MittagsHunger.UI.NetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** MittagsHunger v0.1 GOLD EDITION ***");
            Console.OutputEncoding = Encoding.UTF8;

            var builder = new ContainerBuilder();

            // Register individual components
            //builder.RegisterInstance(new Data.EF.EfRepository()).As<IRepository>();
            builder.RegisterAssemblyTypes(Assembly.LoadFrom(@"C:\Users\ar2\source\repos\ppedvAG\Testing_2020\ppedv.MittagsHunger\ppedv.MittagsHunger.Data.EF\bin\Debug\ppedv.MittagsHunger.Data.EF.dll"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            var container = builder.Build();

            var core = new Core(container.Resolve<IRepository>());

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
