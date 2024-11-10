using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Avatar;
using API.Helpers;
using API.Models;

namespace API.Interface
{
    public interface IAvatarRepo
    {
        Task<List<Avatar>> GetAllAsync (QueryObject queryObject);
        Task<Avatar?> GetByIdAsync (int id);
        Task<Avatar> CreateAsync (Avatar avatarModel);
        Task<bool> AvatarExists (int id); 
        Task<Avatar?> UpdateAsync (int id, UpdateAvatarDto updateAvatar);
        Task<Avatar?> DeleteAsync (int id);

    }
}