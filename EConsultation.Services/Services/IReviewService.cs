using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EConsultation.Models.Models;

namespace EConsultation.Services.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviews(int docid);

        Task<Review> AddReview(Review review);
    }
}
