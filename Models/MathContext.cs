using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BasicMath.Models
{
    public class MathContext : DbContext
    {
        public MathContext(DbContextOptions<MathContext> options)
            : base(options)
        {
        }

        public DbSet<BasicsMath> BasicMaths { get; set; } = null!;
    }
}