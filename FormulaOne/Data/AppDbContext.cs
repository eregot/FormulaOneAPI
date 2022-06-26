using System;
using FormulaOne.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> teams{ get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}

