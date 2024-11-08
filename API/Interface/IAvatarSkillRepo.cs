using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.AvatarSkill;
using API.Models;

namespace API.Interface
{
    public interface IAvatarSkillRepo
    {
        Task<List<AvatarSkill>> GetAllAsync ();
        Task<AvatarSkill?> GetByIdAsync (int id);
        Task<AvatarSkill> CreateAsync (AvatarSkill skillModel);
        Task<AvatarSkill?> UpdateAsync (int id, AvatarSkill skillDto);
        Task<AvatarSkill?> DeleteAsync (int id);
    }
}