using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AppStockRepository : IAppStockRepository
    {
        private readonly AppDbEcommerce _context;
        public AppStockRepository(AppDbEcommerce context)
        {
            _context = context;
        }

        public async Task<AppStock> CreateAsync(AppStock appStock)
        {
            await _context.AppStocks.AddAsync(appStock);
            await _context.SaveChangesAsync();
            return appStock;
        }

        public async Task<AppStock> DeleteStock(AppUser appUser, string brand)
        {
            var stockModel = await _context.AppStocks.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.TShirt.Brand.ToLower() == brand.ToLower());

            if(stockModel == null)
            {
                return null;
            }

            _context.AppStocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<TShirt>> GetUserStock(AppUser user)
        {
            return await _context.AppStocks.Where(x => x.AppUserId == user.Id)
            .Select(tshirt => new TShirt
            {
                Id = tshirt.TShirtId,
                Brand = tshirt.TShirt.Brand,
                Color = tshirt.TShirt.Color,
                Season = tshirt.TShirt.Season,
                
            }).ToListAsync();
        }
    }
}