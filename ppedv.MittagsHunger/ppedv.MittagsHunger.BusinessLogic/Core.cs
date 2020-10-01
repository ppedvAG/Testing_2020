using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.Model.Contracts;
using System.Linq;

namespace ppedv.MittagsHunger.BusinessLogic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Lieferant GetLieferantWithMostKCal()
        {
            return Repository.Query<Lieferant>()
                             .OrderByDescending(x => x.Gerichte.Sum(y => y.KCal))
                             .FirstOrDefault();
        }

    }
}
