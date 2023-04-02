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
    [Route("api/likes")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILogger<LikeController> _logger;
        private readonly ILikeService _likeService;

        public LikeController(ILogger<LikeController> logger, ILikeService likeService)
        {
            _logger = logger;
            _likeService = likeService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<LikeModel>> GetLikeById(string id)
        {
            var like = await _likeService.GetLikeByIdAsync(id);

            if (like == null)
                return NotFound($"There is no View with ID: {id}");

            return Ok(like);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<ActionResult<LikeModel>> GetLikeByProductId(string id)
        {
            var likes = await _likeService.GetLikeByProductId(id);

            if (likes == null)
                return NotFound($"There is no View with ProductID: {id}");

            return Ok(likes);
        }

        [HttpPost]
        public async Task<ActionResult> AddLikes(List<LikeModel> likesModel)
        {
            var added = await _likeService.AddLikesAsync(likesModel);

            if (added)
            {
                return Ok();
            }
            return BadRequest("Unable to add View");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteLikeById(string id)
        {
            var deleted = await _likeService.DeleteLikeAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound($"There is no View with ID: {id}");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLike(LikeModel likeModel)
        {
            var updated = await _likeService.UpdateLike(likeModel);

            if (updated)
            {
                return Ok();
            }

            return BadRequest($"Unable to update view with Id: {likeModel.Id}");
        }
    }
}
