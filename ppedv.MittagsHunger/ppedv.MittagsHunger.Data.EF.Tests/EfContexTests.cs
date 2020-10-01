using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
