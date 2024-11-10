using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.AvatarSkill;
using API.Interface;
using API.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("api/avatarSkill")]
    public class AvatarSkillController : ControllerBase
    {
        private readonly IAvatarSkillRepo _skillRepo;
        private readonly IAvatarRepo _avatarRepo;
        public AvatarSkillController(IAvatarSkillRepo skillRepo, IAvatarRepo avatarRepo)
        {
            _skillRepo = skillRepo;
            _avatarRepo = avatarRepo;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAll ()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = await _skillRepo.GetAllAsync();
            var skillDto = skill.Select(x => x.ToSkillDto());

            return Ok(skillDto);
        }

        [HttpGet("{id:int}")]
        [Authorize]

        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = await _skillRepo.GetByIdAsync(id);
            
            if(skill == null)
            {
                return NotFound();
            }

            return Ok(skill.ToSkillDto());

        }

        [HttpPost("{avatarId:int}")]
        [Authorize]

        public async Task<IActionResult> Create ([FromRoute] int avatarId, CreateAvatarSkillDto skillDto)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!await _avatarRepo.AvatarExists(avatarId))
            {
                return BadRequest("Didn't find any corrisponding ID");
            }

            var skill = skillDto.ToCreateSkillDto(avatarId);
            await _skillRepo.CreateAsync(skill);
            return CreatedAtAction(nameof(GetById), new {id = skill.Id}, skill.ToSkillDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task <IActionResult> Update ([FromRoute] int id, [FromBody] UpdateAvatarSkillDto updateSkill)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = await _skillRepo.UpdateAsync(id, updateSkill.ToUpdateSkillDto());
            
            if (skill == null)
            {
                return NotFound();
            }
            
            return Ok(skill.ToSkillDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]

        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = await _skillRepo.DeleteAsync(id);
            
            if(skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }
    }
}