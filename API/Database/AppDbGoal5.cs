using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class AppDbGoal5 : DbContext
    {
        public AppDbGoal5(DbContextOptions<AppDbGoal5> DbContextOptions) : base (DbContextOptions)
        {
            
        }

        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<AvatarSkill> Skills { get; set; }
    }
}