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