using AppOwnsData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppOwnsData.DB
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {

        }

        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<Reports> Reports { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<RoleReports> RoleReports { get; set; }

        public DbSet<UserRole> UserRole { get; set; }



        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<UserLogin>(entity => {
        //        entity.HasKey(k => k.uid);
        //    });
        //}
    }
}
