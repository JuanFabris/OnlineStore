using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class AppDbEcommerce : IdentityDbContext<AppUser>
    {
        public AppDbEcommerce(DbContextOptions<AppDbEcommerce> dbContextOptions) : base (dbContextOptions)
        {
            
        }

        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AppStock> AppStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppStock>(x => x.HasKey(a => new {a.AppUserId, a.TShirtId}));
            
            builder.Entity<AppStock>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.AppStocks)
                .HasForeignKey(t => t.AppUserId);

            builder.Entity<AppStock>()
                .HasOne(u => u.TShirt)
                .WithMany(u => u.AppStocks)
                .HasForeignKey(t => t.TShirtId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "USer",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }


    }
}