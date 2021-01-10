using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atm;

namespace Atm.Data
{
    public class AtmContext : DbContext
    {
        public AtmContext (DbContextOptions<AtmContext> options)
            : base(options)
        {
        }

        public DbSet<AtmStock> AtmStock { get; set; }
    }
}
