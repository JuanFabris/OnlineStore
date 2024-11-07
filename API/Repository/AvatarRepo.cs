using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTOs.Avatar;
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

        public async Task<Avatar> CreateAsync(Avatar avatarModel)
        {
            await _context.Avatars.AddAsync(avatarModel);
            await _context.SaveChangesAsync();
            return avatarModel;
        }

        public async Task<bool> AvatarExists(int id)
        {
            return await _context.Avatars.AnyAsync(x => x.Id == id);
        }
        
        public async Task<Avatar?> UpdateAsync(int id, UpdateAvatarDto updateAvatar)
        {
            var avatar = await _context.Avatars.FirstOrDefaultAsync(x => x.Id == id);
            
            if (avatar == null)
            {
                return null;
            }

            avatar.Role = updateAvatar.Role;
            avatar.PlayOtherRoles = updateAvatar.PlayOtherRoles;
            avatar.Height = updateAvatar.Height;
            avatar.Weight = updateAvatar.Weight;
            avatar.Experience = updateAvatar.Experience;

            await _context.SaveChangesAsync();
            return avatar;
        }

        public async Task<Avatar?> DeleteAsync(int id)
        {
            var avatar = await _context.Avatars.FindAsync(id);

            if(avatar != null)
            {
                _context.Avatars.Remove(avatar);
                await _context.SaveChangesAsync();
            }

            return avatar;
        }
    }
}