using EConsultation.Models.Context;
using EConsultation.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsultation.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly EConsultContext _eConsultContext;

        public ReviewService(EConsultContext eConsultContext)
        {
            this._eConsultContext = eConsultContext;
        }

        public async Task<Review> AddReview(Review review)
        {
            var result = await _eConsultContext.Reviews.AddAsync(review);
            await _eConsultContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Review>> GetReviews(int docid)
        {
            return await _eConsultContext.Reviews.Where(e => e.DoctorID == docid).ToListAsync();
        }
    }
}
