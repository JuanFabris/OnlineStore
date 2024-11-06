using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface IAvatarRepo
    {
        Task<List<Avatar>> GetAllAsync ();
        Task<Avatar?> GetByIdAsync (int id);
        Task<Avatar> CreateAsync (Avatar avatarModel);
    }
}