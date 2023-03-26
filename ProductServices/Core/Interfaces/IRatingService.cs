using DB.Models;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Interfaces
{
    public interface IRatingService
    {
        public Task<bool> AddRatingAsync(RatingModel rating);

        public Task<bool> DeleteRatingAsync(string id);

        public Task<RatingModel> GetRatingByIdAsync(string id);

        public Task<bool> UpdateRating(RatingModel rating, string id);

        public Task<IEnumerable<RatingModel>> GetAllRatingsAsync();

        public Task<bool> AddRatingsAsync(IEnumerable<RatingModel> ratings);
    }
}
