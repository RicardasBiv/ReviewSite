using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IRecenzijuService _reviewService;
        public ReviewController(IRecenzijuService reviewService)
        {
            _reviewService = reviewService;
        }
        // GET: api/review
        //[Authorize(Roles = "Admin,Writer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllReview()
        {
            var products = await _reviewService.GetReviews();
            return Ok(products);
        }
        [HttpGet("user/{userid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllYourReview(int userid)
        {
            var products = await _reviewService.GetYourReviews(userid);
            if (products == null)
            {
                return NotFound($"User with userid = {userid} not found");
            }
            return Ok(products);
        }

        // GET: api/review/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _reviewService.GetReview(id);

            if (review == null)
            {
                return NotFound($"Review with id = {id} not found");
            }
            return Ok(review);
        }
        // Post api/review
       // [Authorize(Roles = "Admin,Writer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddReview([FromBody] ReviewRequest reviewRequest)
        {
            var review = await _reviewService.AddReview(reviewRequest);
            if (review == null)
            {
                return BadRequest("Incorrect data review");
            }
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }
        // Put api/review/id
        //[Authorize(Roles = "Admin,Writer")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] ReviewUpdateRequest reviewRequest)
        {
            var review = await _reviewService.GetReview(id);
            if (review == null)
            {
                return NotFound($"Review with id = {id} not found");
            }
            var reviewUpdated = await _reviewService.UpdateReview(id, reviewRequest);
            if (reviewUpdated == null)
            {
                return BadRequest();
            }
            return Ok(reviewUpdated);
        }
        //[Authorize(Roles = "Admin,Writer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            var review = await _reviewService.GetReview(id);
            if (review == null)
            {
                return NotFound($"Review with id = {id} not found");
            }
            var reviewDeleted = await _reviewService.DeleteReview(id);

            return Ok(reviewDeleted);
        }


    }
}
