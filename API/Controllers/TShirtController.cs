using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.HelperToQuery;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tshirt")]
    public class TShirtController : ControllerBase
    {
        private readonly ITShirtRepository _tShirtRepo;
        public TShirtController(ITShirtRepository tShirtRepo)
        {
            _tShirtRepo = tShirtRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll ([FromQuery] QueryObject queryObject)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tShirt = await _tShirtRepo.GetAllAsync(queryObject);

            var tshirtDto = tShirt.Select(t => t.IntoTShirtDto());

            return Ok(tShirt);
        }

        [HttpGet("{id:int}")]
        public async Task <IActionResult> GetById ([FromRoute]int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tShirt = await _tShirtRepo.GetByIdAsync(id);

            if(tShirt == null)
            {
                return NotFound();
            }

            return Ok(tShirt.IntoTShirtDto());
        }

        [HttpPost]
        [Authorize]
        public async Task <IActionResult> Create ([FromBody] CreateTShirtDto tshirtDTo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tShirtModel = tshirtDTo.ToUpdateDto();
            await _tShirtRepo.CreateAsync(tShirtModel);
            return CreatedAtAction(nameof(GetById), new {id = tShirtModel.Id}, tShirtModel.IntoTShirtDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateTshirtDto updateTshirtDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tShirtModel = await _tShirtRepo.UpdateAsync(id, updateTshirtDto);
            if(tShirtModel == null)
            {
                return NotFound();
            }
            return Ok(tShirtModel.IntoTShirtDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedTShirt = await _tShirtRepo.DeleteAsync(id);

            if (deletedTShirt == null)
            {
                return NotFound("No corresponding TShirt found with the specified ID.");
            }

            return NoContent();
        }
    }
}