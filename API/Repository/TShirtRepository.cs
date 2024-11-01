using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class TShirtRepository : ITShirtRepository
    {
        private readonly AppDbEcommerce _merch;
        public TShirtRepository(AppDbEcommerce merch)
        {
            _merch = merch;
        }

        public async Task<TShirt> CreateAsync(TShirt tShirtModel)
        {
            await _merch.TShirts.AddAsync(tShirtModel);
            await _merch.SaveChangesAsync();
            return tShirtModel;
        }

        public async Task<TShirt?> DeleteAsync(int id)
        {
            var existingTshirt = await _merch.TShirts.FirstOrDefaultAsync(x => x.Id == id);
            if(existingTshirt == null)
            {
                return null;
            }
            
            _merch.TShirts.Remove(existingTshirt);
            await _merch.SaveChangesAsync();
            return existingTshirt;
            
        }

        public async Task<List<TShirt>> GetAllAsync()
        {
            return await _merch.TShirts.ToListAsync();
        }

        public async Task<TShirt?> GetByIdAsync(int id)
        {
            return await _merch.TShirts.FindAsync(id);
        }

        public async Task<bool> TshirtExists(int id)
        {
            return await _merch.TShirts.AnyAsync(x => x.Id == id);
        }

        public async Task<TShirt?> UpdateAsync(int id, UpdateTshirtDto updateTshirtDto)
        {
            var existingTshirt = await _merch.TShirts.FirstOrDefaultAsync(x => x.Id == id);
            if(existingTshirt == null)
            {
                return null;
            }

            existingTshirt.Brand = updateTshirtDto.Brand;
            existingTshirt.Color = updateTshirtDto.Color;
            existingTshirt.Season = updateTshirtDto.Season;
            existingTshirt.Prize = updateTshirtDto.Prize;

            await _merch.SaveChangesAsync();
            return existingTshirt; 
        }
    }
}