using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ppedv.MittagsHunger.Model;

namespace ppedv.MittagsHunger.UI.Web.Data
{
    public class ppedvMittagsHungerUIWebContext : DbContext
    {
        public ppedvMittagsHungerUIWebContext (DbContextOptions<ppedvMittagsHungerUIWebContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ppedv.MittagsHunger.Model.Gericht> Gericht { get; set; }
    }
}
