using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Models;

namespace API.Interfaces
{
    public interface ITShirtRepository
    {
        Task<List<TShirt>> GetAllAsync ();
        Task<TShirt?> GetByIdAsync (int id);
        Task<TShirt> CreateAsync (TShirt tShirtModel);
        Task<TShirt?> UpdateAsync (int id, UpdateTshirtDto updateTshirtDto);
        Task<TShirt?> DeleteAsync (int id);
        Task<bool> TshirtExists (int id);
        
    }
}