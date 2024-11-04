using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Review;
using API.Models;

namespace API.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToReviewDto (this Review reviewModel )
        {
            return new ReviewDto
            {
                Id = reviewModel.Id,
                Rating = reviewModel.Rating,
                Description = reviewModel.Description,
                CreatedBy = reviewModel.AppUser.UserName,
                TshirtId = reviewModel.TshirtId,
            };
        }

        public static Review ToCreateReview (this CreateReviewDto reviewDto, int TshirtId)
        {
            return new Review 
            
            {
                Rating = reviewDto.Rating,
                Description = reviewDto.Description,
                TshirtId = TshirtId
            };
        }

        public static Review ToUpdateReview (this UpdateReview reviewDto)
        {
            return new Review
            {
                Rating = reviewDto.Rating,
                Description = reviewDto.Description,
            };
        }
    }
}