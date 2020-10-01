using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.MittagsHunger.BusinessLogic.Tests
{
    public class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Lieferant))
            {
                var l1 = new Lieferant() { Name = "L1" };
                l1.Gerichte.Add(new Gericht() { Name = "G1", KCal = 37 });
                l1.Gerichte.Add(new Gericht() { Name = "G2", KCal = 100 });

                var l2 = new Lieferant() { Name = "L2" };
                l2.Gerichte.Add(new Gericht() { Name = "G1", KCal = 237 });
                l2.Gerichte.Add(new Gericht() { Name = "G2", KCal = 200 });

                return new[] { l1, l2 }.Cast<T>().AsQueryable();
            }

            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }
    }
}
