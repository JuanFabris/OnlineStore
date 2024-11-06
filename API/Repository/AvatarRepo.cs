using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AvatarRepo : IAvatarRepo
    {
        private readonly AppDbGoal5 _context;
        public AvatarRepo(AppDbGoal5 context)
        {
            _context = context;
        }

        public async Task<List<Avatar>> GetAllAsync()
        {
            return await _context.Avatars.ToListAsync();
        }

        public async Task<Avatar?> GetByIdAsync(int id)
        {
            return await _context.Avatars.FindAsync(id);
        }

        public Task<Avatar> CreateAsync(Avatar avatarModel)
        {
            throw new NotImplementedException();
        }
    }
}