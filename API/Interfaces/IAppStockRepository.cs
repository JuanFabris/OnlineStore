using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IAppStockRepository
    {
        Task <List<TShirt>> GetUserStock (AppUser user);
        Task <AppStock> CreateAsync (AppStock appStock);
        Task <AppStock> DeleteStock (AppUser appUser, string brand);
    }
}