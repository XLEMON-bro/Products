using DB.Models;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Interfaces
{
    public interface ILikeService
    {
        public Task<bool> AddLikeAsync(LikeModel like);

        public Task<bool> DeleteLikeAsync(string id);

        public Task<LikeModel> GetLikeByIdAsync(string id);

        public Task<bool> UpdateLike(LikeModel like, string id);

        public Task<IEnumerable<LikeModel>> GetAllLikesAsync();

        public Task<bool> AddLikesAsync(IEnumerable<LikeModel> likes);
    }
}
