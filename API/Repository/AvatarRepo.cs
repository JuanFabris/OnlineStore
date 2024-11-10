using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTOs.Avatar;
using API.Helpers;
using API.Interface;
using API.Migrations;
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

        public async Task<List<Avatar>> GetAllAsync(QueryObject queryObject)
        {
            var avatars = _context.Avatars.Include(x => x.Skill).AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(queryObject.FavouriteFoot))
            {
                avatars = avatars.Where(s => s.FavouriteFoot.Contains(queryObject.FavouriteFoot));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.Role))
            {
                avatars = avatars.Where(s => s.Role.Contains(queryObject.Role));
            }

            // Execute the query to get avatars
            var avatarList = await avatars.ToListAsync();

            // Apply sorting client-side
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy) && queryObject.SortBy.Equals("Rating", StringComparison.OrdinalIgnoreCase))
            {
                avatarList = queryObject.IsDescending
                    ? avatarList.OrderByDescending(t => t.Rating).ToList()
                    : avatarList.OrderBy(t => t.Rating).ToList();
            }

            return avatarList;
        }

        public async Task<Avatar?> GetByIdAsync(int id)
        {
            return await _context.Avatars.Include(x => x.Skill).FirstOrDefaultAsync(x => x.Id == id);
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
            //avatar.Experience = updateAvatar.Experience;

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