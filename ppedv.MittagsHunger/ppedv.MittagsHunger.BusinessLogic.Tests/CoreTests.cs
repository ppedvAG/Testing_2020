using FluentAssertions;
using Moq;
using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.Model.Contracts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ppedv.MittagsHunger.BusinessLogic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetLieferantWithMostKCal_Two_Lieferanten_second_one_has_more_KCal()
        {
            var core = new Core(new TestRepository());

            var result = core.GetLieferantWithMostKCal();

            result.Name.Should().Be("L2");
        }

        [Fact]
        public void GetLieferantWithMostKCal_Two_Lieferanten_second_one_has_more_KCal_MOCK_mit_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Lieferant>()).Returns(() =>
            {
                var l1 = new Lieferant() { Name = "L1" };
                l1.Gerichte.Add(new Gericht() { Name = "G1", KCal = 37 });
                l1.Gerichte.Add(new Gericht() { Name = "G2", KCal = 100 });

                var l2 = new Lieferant() { Name = "L2" };
                l2.Gerichte.Add(new Gericht() { Name = "G1", KCal = 237 });
                l2.Gerichte.Add(new Gericht() { Name = "G2", KCal = 200 });

                return new[] { l1, l2 }.AsQueryable();
            });
            var core = new Core(mock.Object);

            var result = core.GetLieferantWithMostKCal();

            result.Name.Should().Be("L2");

            mock.Verify(x => x.Query<Lieferant>(), Times.AtLeast(1));
        }

        [Fact]
        public void GetLieferantWithMostKCal_no_Liefernaten_results_null()
        {
            var mock = new Mock<IRepository>();

            mock.Setup(x => x.Query<Lieferant>()).Returns(() =>
            {
                return new List<Lieferant>().AsQueryable();
            });
            var core = new Core(mock.Object);

            var result = core.GetLieferantWithMostKCal();

            result.Name.Should().BeNull();
        }

        [Fact]
        public void GetLieferantWithMostKCal_Liefernaten_have_no_Gerichte_results_null()
        {
            var mock = new Mock<IRepository>();

            mock.Setup(x => x.Query<Lieferant>()).Returns(() =>
            {
                var l1 = new Lieferant() { Name = "L1" };
                var l2 = new Lieferant() { Name = "L2" };

                return new[] { l1, l2 }.AsQueryable();
            });
            var core = new Core(mock.Object);

            var result = core.GetLieferantWithMostKCal();

            result.Name.Should().BeNull();
        }

        [Fact]
        public void GetLieferantWithMostKCal_two_Liefernaten_have_the_same_sum_of_KCal_result_L1()
        {
            var mock = new Mock<IRepository>();

            mock.Setup(x => x.Query<Lieferant>()).Returns(() =>
            {
                var l1 = new Lieferant() { Name = "L1" };
                l1.Gerichte.Add(new Gericht() { Name = "G1", KCal = 100 });
                l1.Gerichte.Add(new Gericht() { Name = "G2", KCal = 100 });

                var l2 = new Lieferant() { Name = "L2" };
                l2.Gerichte.Add(new Gericht() { Name = "G1", KCal = 150 });
                l2.Gerichte.Add(new Gericht() { Name = "G2", KCal = 50 });

                return new[] { l1, l2 }.AsQueryable();
            });
            var core = new Core(mock.Object);

            var result = core.GetLieferantWithMostKCal();

            result.Name.Should().BeNull();
        }
    }
}
