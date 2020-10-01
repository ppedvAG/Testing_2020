using ppedv.MittagsHunger.Model.Contracts;

namespace ppedv.MittagsHunger.BusinessLogic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }


    }
}
