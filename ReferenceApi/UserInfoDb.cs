using Microsoft.EntityFrameworkCore;
using ReferenceApi.Models;

namespace ReferenceApi
{
    public class UserInfoDb : DbContext
    {
        public UserInfoDb()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<UserInfo> UserInfo { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userinfo.db");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
