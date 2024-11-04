using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/AppStock")]
    public class AppStockController : ControllerBase {
    private readonly UserManager<AppUser> _userManager;
    private readonly ITShirtRepository _tShirtRepo;
    private readonly IAppStockRepository _stockRepository;
    
        public AppStockController(UserManager<AppUser> userManager, ITShirtRepository tShirtRepo, IAppStockRepository stockRepository)
        {
            _userManager = userManager;
            _tShirtRepo = tShirtRepo;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserStock ()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userAppStock = await _stockRepository.GetUserStock(appUser);
            return Ok(userAppStock);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserStock(string brand)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _tShirtRepo.GetByBrandAsync(brand);

            if(stock == null)
            {
                return BadRequest("Stock Not Found");
            }

            var userStock = await _stockRepository.GetUserStock(appUser);

            if(userStock.Any(e => e.Brand.ToLower() == brand.ToLower())) return BadRequest("Cannot add same stock");

            var userStockModel = new AppStock
            {
                TShirtId = stock.Id,
                AppUserId =appUser.Id
            };

            await _stockRepository.CreateAsync(userStockModel);

            if(userStockModel == null)
            {
                return StatusCode(500, "Could Not Create");
            }
            else
            {
                return Created();
            }

        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserStock (string brand)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userStock = await _stockRepository.GetUserStock(appUser);

            var filterStock = userStock.Where(b => b.Brand.ToLower() == brand.ToLower()).ToList();

            if(filterStock.Count() == 1)
            {
                await _stockRepository.DeleteStock(appUser, brand);
            }
            else
            {
                return BadRequest("Stock is not in your Portfolio");
            }

            return Ok();
        }
    }
}