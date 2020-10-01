using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.MittagsHunger.Model;

namespace ppedv.MittagsHunger.Data.EF.Tests
{
    [TestClass]
    public class EfContexTests
    {
        [TestMethod]
        public void EfContext_can_create_DB()
        {
            var con = new EfContext();
            if (con.Database.Exists())
                con.Database.Delete();

            con.Database.Create();

            Assert.IsTrue(con.Database.Exists());
        }

        [TestMethod]
        public void EfContext_can_add_Gericht()
        {
            //Express Profiler Download: https://github.com/OleksiiKovalov/expressprofiler/issues/2#issuecomment-432617835


            var gericht = new Gericht() { Name = "Gyros", Preis = 7.5m, KCal = 780, Vegetarisch = false };
            using (var con = new EfContext())
            {
                con.Gerichte.Add(gericht);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Gerichte.Find(gericht.Id);
                Assert.AreEqual(gericht.Name, loaded.Name);
            }
        }
    }
}
