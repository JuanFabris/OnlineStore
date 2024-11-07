using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Avatar;
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

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avatar = await _avatarRepo.GetAllAsync();
            var avatarDto = avatar.Select(a => a.ToAvatarDto()).ToList();

            return Ok(avatarDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avatar = await _avatarRepo.GetByIdAsync(id);
            if(avatar == null)
            {
                return NotFound("Didn't Find any player");
            }

            return Ok(avatar.ToAvatarDto());
        }

        [HttpPost]
        public async Task <IActionResult> Create ([FromBody] CreateAvatarDto avatarDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avatar = avatarDto.ToCreateDto();
            await _avatarRepo.CreateAsync(avatar);
            return CreatedAtAction(nameof(GetById), new {id = avatar.Id}, avatar.ToAvatarDto());
            
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateAvatarDto updateAvatar)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avatar = await _avatarRepo.UpdateAsync(id, updateAvatar);

            if(avatar == null)
            {
                return NotFound();
            }

            return Ok(avatar.ToAvatarDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avatar = await _avatarRepo.DeleteAsync(id);

            if (avatar == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}