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
            var username = User.GetUSername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userAppStock = await _stockRepository.GetUserStock(appUser);
            return Ok(userAppStock);
        }
    }
}