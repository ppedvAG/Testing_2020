using System;
using System.Globalization;
using AutoFixture;
using FluentAssertions;
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

            //Assert.IsTrue(con.Database.Exists());
            con.Database.Exists().Should().BeTrue();
        }

        [TestMethod]
        public void EfContext_can_add_Gericht()
        {
            //Express Profiler Download: https://github.com/OleksiiKovalov/expressprofiler/issues/2#issuecomment-432617835

            var gericht = new Gericht() { Name = $"Gyros_{Guid.NewGuid()}", Preis = 7.5m, KCal = 780, Vegetarisch = false };
            using (var con = new EfContext())
            {
                con.Gerichte.Add(gericht);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Gerichte.Find(gericht.Id);
                //Assert.AreEqual(gericht.Name, loaded.Name);
                loaded.Name.Should().Be(gericht.Name);
                //Assert.AreEqual(gericht.Preis, loaded.Preis);
                loaded.Preis.Should().Be(gericht.Preis);
                //Assert.AreEqual(gericht.KCal, loaded.KCal);
                loaded.KCal.Should().BeCloseTo(gericht.KCal, 2);
                //Assert.AreEqual(gericht.Vegetarisch, loaded.Vegetarisch);
                loaded.Vegetarisch.Should().Be(gericht.Vegetarisch);

            }
        }

        [TestMethod]
        public void EfContext_can_add_Gericht_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            //fix.Build<Bestelltag>().With(x => x.Datum, TaiwanCalendar);

            var tag = fix.Create<Bestelltag>();

            using (var con = new EfContext())
            {
                con.Bestelltage.Add(tag);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Bestelltage.Find(tag.Id);

                loaded.Should().BeEquivalentTo(tag, c =>
                {
                    c.IgnoringCyclicReferences();
                    c.Using<DateTime>(dd => dd.Subject.Should().BeCloseTo(dd.Expectation)).WhenTypeIs<DateTime>();
                    return c;
                });
            }

        }
    }
}
