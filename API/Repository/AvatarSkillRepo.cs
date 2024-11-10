using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTOs.AvatarSkill;
using API.Interface;
using API.Models;
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

        public async Task<AvatarSkill> CreateAsync(AvatarSkill skillModel)
        {
            await _context.AddAsync(skillModel);
            await _context.SaveChangesAsync();
            return skillModel;
        }

        public async Task<AvatarSkill?> DeleteAsync(int id)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if( skill == null)
            {
                return null;
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<List<AvatarSkill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<AvatarSkill?> GetByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<AvatarSkill?> UpdateAsync( int id, AvatarSkill skillDto)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);

            if(skill == null)
            {
                return null;
            }

            skill.Agility = skillDto.Agility;
            skill.Speed = skillDto.Speed;
            skill.Strength = skillDto.Strength;
            skill.Stamina = skillDto.Stamina;
            skill.Agility = skillDto.Agility;
            skill.Balance = skillDto.Balance;
            skill.Attack = skillDto.Attack;
            skill.Dribbling = skillDto.Dribbling;
            skill.Shooting = skillDto.Shooting;
            skill.BallControll = skillDto.BallControll;
            skill.Passing = skillDto.Passing;
            skill.BoxToBox = skillDto.BoxToBox;
            skill.Defense = skillDto.Defense;
            skill.Marking = skillDto.Marking;
            skill.Tackling = skillDto.Tackling;
            skill.Diving = skillDto.Diving;
            skill.Handling = skillDto.Handling;
            skill.Reflexes = skillDto.Reflexes;

            await _context.SaveChangesAsync();
            return skill;
        
        }
    }
}
