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
    [Route("api/skill")]
    public class AvatarSkillController : ControllerBase
    {
        private readonly IAvatarSkillRepo _avatarSkillRepo;
        public AvatarSkillController(IAvatarSkillRepo avatarSkillRepo)
        {
            _avatarSkillRepo = avatarSkillRepo;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll ()
        {
            var avatar = await _avatarSkillRepo.GetAllAsync();
            var avatarDto = avatar.Select(x => x.ToAvatarSkillDto());

            return Ok(avatarDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var avatar = await _avatarSkillRepo.GetByIdAsync(id);

            if(avatar == null)
            {
                return NotFound();
            }

            return Ok (avatar.ToAvatarSkillDto());
        }
    }
}