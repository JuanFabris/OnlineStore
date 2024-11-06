using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("api/avatar")]
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarRepo _avatarRepo;
        public AvatarController(IAvatarRepo avatarRepo)
        {
            _avatarRepo = avatarRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var avatar = await _avatarRepo.GetAllAsync();
            var avatarDto = avatar.Select(a => a.toAvatarDto()).ToList();

            return Ok(avatarDto);
        }
    }
}