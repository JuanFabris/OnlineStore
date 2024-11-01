using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Review;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ITShirtRepository _tShirtRepository;
        public ReviewController(IReviewRepository reviewRepository, ITShirtRepository tShirtRepository)
        {
            _reviewRepository = reviewRepository;
            _tShirtRepository = tShirtRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var review = await _reviewRepository.GetAllAsync();

            var reviewDto = review.Select(x => x.ToReviewDto());

            return Ok(review);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);

            if(review == null)
            {
                return NotFound();
            }

            return Ok(review.ToReviewDto());
        }

        [HttpPost("{tshirtId}")]
        public async Task<IActionResult> Create ([FromRoute] int tshirtId, CreateReviewDto reviewDto)
        {
            if(!await _tShirtRepository.TshirtExists(tshirtId))
            {
                return BadRequest("Didn't find any corrisponding ID");
            }

            var reviewModel = reviewDto.ToCreateReview(tshirtId);
            await _reviewRepository.CreateAsync(reviewModel);
            return CreatedAtAction(nameof(GetById), new {id = reviewModel.Id}, reviewModel.ToReviewDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateReview updateReview)
        {
            var review = await _reviewRepository.UpdateAsync(id, updateReview.ToUpdateReview());
            if(review == null)
            {
                return NotFound();
            }
            return Ok(review.ToReviewDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            var review = await _reviewRepository.DeleteAsync(id);
            if(review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
    }
}