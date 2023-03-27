using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly ILogger<RatingController> _logger;
        private readonly IRatingService _ratingService;

        public RatingController(ILogger<RatingController> logger, IRatingService ratingService)
        {
            _logger = logger;
            _ratingService = ratingService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RatingModel>> GetRatingById(string id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);

            if (rating == null)
                return NotFound($"There is no View with ID: {id}");

            return Ok(rating);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetRatingsByProductId(string id)
        {
            var rating = await _ratingService.GetRatingsByProductId(id);

            if (rating == null)
                return NotFound($"There is no View with ProductID: {id}");

            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult> AddRating(RatingModel ratingModel)
        {
            var added = await _ratingService.AddRatingAsync(ratingModel);

            if (added)
            {
                return Ok();
            }
            return BadRequest("Unable to add View");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteRatingById(string id)
        {
            var deleted = await _ratingService.DeleteRatingAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound($"There is no View with ID: {id}");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRating(RatingModel ratingModel)
        {
            var updated = await _ratingService.UpdateRating(ratingModel);

            if (updated)
            {
                return Ok();
            }

            return BadRequest($"Unable to update view with Id: {ratingModel.Id}");
        }
    }
}
