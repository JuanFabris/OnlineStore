using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using API.Mappers;
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
        public async Task<IActionResult> GetAll ()
        {
            var tShirt = await _tShirtRepo.GetAllAsync();

            var tshirtDto = tShirt.Select(t => t.IntoTShirtDto());

            return Ok(tShirt);
        }

        [HttpGet("{id:int}")]
        public async Task <IActionResult> GetById ([FromRoute]int id)
        {
            var tShirt = await _tShirtRepo.GetByIdAsync(id);

            if(tShirt == null)
            {
                return NotFound();
            }

            return Ok(tShirt.IntoTShirtDto());
        }

        [HttpPost]
        public async Task <IActionResult> Create ([FromBody] CreateTShirtDto tshirtDTo)
        {
            var tShirtModel = tshirtDTo.ToUpdateDto();
            await _tShirtRepo.CreateAsync(tShirtModel);
            return CreatedAtAction(nameof(GetById), new {id = tShirtModel.Id}, tShirtModel.IntoTShirtDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateTshirtDto updateTshirtDto)
        {
            var tShirtModel = await _tShirtRepo.UpdateAsync(id, updateTshirtDto);
            if(tShirtModel == null)
            {
                return NotFound();
            }
            return Ok(tShirtModel.IntoTShirtDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            var TshirtExists = await _tShirtRepo.DeleteAsync(id);

            if(TshirtExists == null)
            {
                return NotFound("i din't find a corrresponding ID sir");
            }

            return NoContent();
        }
    }
}