using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.DTO.Review;
using API.HelperToQuery;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbEcommerce _rev;
        public ReviewRepository(AppDbEcommerce rev)
        {
            _rev = rev;
        }
        public async Task<List<Review>> GetAllAsync(ReviewQueryObject queryObject)
        {
            var reviews = _rev.Reviews.Include(r => r.AppUser).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(queryObject.Brand))
            {
                reviews = reviews.Where(s => s.TShirt.Brand == queryObject.Brand);
            }

            if(queryObject.isDecsending == true)
            {
                reviews = reviews.OrderByDescending(r => r.Rating);
            }

            return await reviews.ToListAsync();
         
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _rev.Reviews.Include(r => r.AppUser).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Review> CreateAsync (Review reviewModel)
        {
            await _rev.Reviews.AddAsync(reviewModel);
            await _rev.SaveChangesAsync();
            return reviewModel;
        }

        public async Task<Review?> UpdateAsync(int id, Review updateReview)
        {
            var existingRev = await _rev.Reviews.FindAsync(id);
            if(existingRev == null)
            {
                return null;
            }
            
            existingRev.Rating = updateReview.Rating;
            existingRev.Description = updateReview.Description;

            await _rev.SaveChangesAsync();
            return existingRev;
        }

        public async Task<Review?> DeleteAsync(int id)
        {
            var review = await _rev.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if(review == null)
            {
                return null;
            }
            _rev.Reviews.Remove(review);
            await _rev.SaveChangesAsync();
            return review;
        }
    }
}