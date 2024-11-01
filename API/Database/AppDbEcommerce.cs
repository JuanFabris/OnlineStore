using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class AppDbEcommerce : DbContext
    {
        public AppDbEcommerce(DbContextOptions<AppDbEcommerce> dbContextOptions) : base (dbContextOptions)
        {
            
        }

        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}