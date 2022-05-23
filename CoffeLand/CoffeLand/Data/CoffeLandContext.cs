using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeLand.Models;

namespace CoffeLand.Data
{
    public class CoffeLandContext : DbContext
    {
        public CoffeLandContext (DbContextOptions<CoffeLandContext> options)
            : base(options)
        {
        }

        public DbSet<CoffeLand.Models.Coffe> Coffe { get; set; }
    }
}
