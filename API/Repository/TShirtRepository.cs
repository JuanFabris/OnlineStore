using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTO;
using API.HelperToQuery;
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
            var reviews = _merch.Reviews.Where(r => r.TshirtId == id);
            _merch.Reviews.RemoveRange(reviews);

            var tShirt = await _merch.TShirts.FindAsync(id);
            if (tShirt != null)
            {
                _merch.TShirts.Remove(tShirt);
                await _merch.SaveChangesAsync();
            }

            return tShirt;  
        }


        public async Task<List<TShirt>> GetAllAsync(QueryObject queryObject)
        {
            var tshirt = _merch.TShirts.Include(x => x.Reviews).AsQueryable();
            
            //filter
            if(!string.IsNullOrWhiteSpace(queryObject.Brand))
            {
                tshirt = tshirt.Where(t => t.Brand.Contains(queryObject.Brand));
            }

            if(!string.IsNullOrWhiteSpace(queryObject.Color))
            {
                tshirt = tshirt.Where(t => t.Color.Contains(queryObject.Color));
            }

            if(!string.IsNullOrWhiteSpace(queryObject.Season))
            {
                tshirt = tshirt.Where(t => t.Season.Contains(queryObject.Season));
            }

            //Sort
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy) && queryObject.SortBy.Equals("Prize", StringComparison.OrdinalIgnoreCase))
            {
                tshirt = queryObject.IsDecsending ? tshirt.OrderByDescending(t => t.Prize) : tshirt.OrderBy(t => t.Prize);
            }


            return await tshirt.ToListAsync();
        }

        public async Task<TShirt?> GetByIdAsync(int id)
        {
            return await _merch.TShirts.Include(s => s.Reviews).FirstOrDefaultAsync(p => p.Id == id); //Get unique Ids

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