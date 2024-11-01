using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Review;
using API.Models;

namespace API.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync ();
        Task<Review?> GetByIdAsync(int id);
        Task<Review> CreateAsync (Review reviewModel);
        Task<Review?> UpdateAsync (int id, Review updateReview);
        Task<Review?> DeleteAsync (int id);
    }
}