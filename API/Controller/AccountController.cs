using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Account;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _token;
        private readonly SignInManager<AppUser> _signingManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService token, SignInManager<AppUser> signingManager)
        {
            _userManager = userManager;
            _signingManager = signingManager;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterDto registerDto)
        {
            try {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var AppUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(AppUser, registerDto.Password);

                if(createdUser.Succeeded)
                {
                    var userRole = await _userManager.AddToRoleAsync(AppUser, "User");

                    if(userRole.Succeeded)
                    {
                        return Ok (
                            new NewUserDto
                            {
                                Username = AppUser.UserName,
                                Email = AppUser.Email,
                                Token = _token.CreateToken(AppUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return StatusCode(500);
                }
            } catch(Exception e) {

                return StatusCode(500, e);
            } 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            
            if(user == null)
            {
                return Unauthorized("Invalid Username!");
            }

            var result = await _signingManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded)
            {
                return Unauthorized("username not found or password incorrect!");
            }

            return Ok
            (
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _token.CreateToken(user)
                }
            );
        }
    }
}