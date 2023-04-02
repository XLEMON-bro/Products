using AutoMapper;
using DB.Interfaces;
using DB.Models;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
using ProductServices.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Services
{
    public class LikeService : ILikeService
    {
        ILikeRepository<Like> _likeRepository;
        IMapper _mapper;
        public LikeService(ILikeRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddLikeAsync(LikeModel likeModel)
        {
            var like = _mapper.Map<Like>(likeModel);

            var guid = GuidHelper.GenerateGuid();

            while(await _likeRepository.GetByIdAsync(guid) != null)
            {
                guid = GuidHelper.GenerateGuid();
            }

            like.Id = guid;

            return await _likeRepository.AddAsync(like);
        }

        public async Task<bool> AddLikesAsync(IEnumerable<LikeModel> likesModel)
        {
            var likes = _mapper.Map<List<Like>>(likesModel);

            var guid = string.Empty;

            foreach(var like in likes)
            {
                guid = GuidHelper.GenerateGuid();

                while (await _likeRepository.GetByIdAsync(guid) != null)
                {
                    guid = GuidHelper.GenerateGuid();
                }

                like.Id = guid;
            }

            return await _likeRepository.AddRangeAsync(likes);
        }

        public async Task<bool> DeleteLikeAsync(string id)
        {
            return await _likeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LikeModel>> GetAllLikesAsync()
        {
            var likes = await _likeRepository.GetAllAsync();

            return _mapper.Map<List<LikeModel>>(likes);
        }

        public async Task<LikeModel> GetLikeByIdAsync(string id)
        {
            var like = await _likeRepository.GetByIdAsync(id);

            if (like == null)
                return null;

            return _mapper.Map<LikeModel>(like);
        }

        public async Task<bool> UpdateLike(LikeModel likeModel)
        {
            var like = await _likeRepository.GetByIdAsync(likeModel.Id);

            if (like == null)
            {
                return false;
            }

            like.ProductId = likeModel.ProductId;
            like.TotalLikes = likeModel.TotalLikes;
            like.TotalDislikes = likeModel.TotalDislikes;
            like.TodayLikes = likeModel.TodayLikes;
            like.TodayDislikes = likeModel.TodayDislikes;

            return await _likeRepository.Update(like);
        }

        public async Task<LikeModel> GetLikeByProductId(string productId)
        {
            var view = await _likeRepository.GetLikeByProductId(productId);

            if (view == null)
            {
                return null;
            }

            return _mapper.Map<LikeModel>(view);
        }
    }
}
