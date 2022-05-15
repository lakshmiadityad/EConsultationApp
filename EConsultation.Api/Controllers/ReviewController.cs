using EConsultation.Models.Models;
using EConsultation.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EConsultation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this._reviewService=reviewService;
        }
        [EnableCors]
        [HttpGet("docid")]
        public async Task<ActionResult<Review>> GetReviews(int docid)
        {
            try
            {
                return Ok(await _reviewService.GetReviews(docid));
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Review>> AddReview(Review review)
        {
            try
            {
                if (review == null)
                    return BadRequest();

                var addedReview = await _reviewService.AddReview(review);
                return addedReview;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new review");
            }
        }
    }
}
