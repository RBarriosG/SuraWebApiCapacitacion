using System;
using Microsoft.EntityFrameworkCore;
using sura.Models;

namespace sura
{
    public class ContextoDB : DbContext 
    {
        public ContextoDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cita> Citas { get; set; }
    }
}
