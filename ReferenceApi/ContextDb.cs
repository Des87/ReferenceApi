using Microsoft.EntityFrameworkCore;
using ReferenceApi.Models;

namespace ReferenceApi
{
    public class ContextDb : DbContext
    {
        public ContextDb()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Condition>? Condition { get; set; }
        public virtual DbSet<Current>? Current { get; set; }
        public virtual DbSet<Location>? Location { get; set; }
        public virtual DbSet<Weather>? Weather { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
