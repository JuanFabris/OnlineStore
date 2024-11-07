using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTOs.AvatarSkill;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AvatarSkillRepo : IAvatarSkillRepo
    {
        private readonly AppDbGoal5 _context;
        public AvatarSkillRepo(AppDbGoal5 context)
        {
            _context = context;
        }

        public async Task<AvatarSkill> CreateAsync(AvatarSkill avatarSkill)
        {
            await _context.Skills.AddAsync(avatarSkill);
            await _context.SaveChangesAsync();
            return avatarSkill;
        }

        public async Task<List<AvatarSkill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<AvatarSkill?> GetByIdAsync (int id)
        {
            return await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}