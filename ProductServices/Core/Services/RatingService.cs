using AutoMapper;
using DB.Interfaces;
using DB.Models;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Services
{
    public class RatingService : IRatingService
    {
        IRepository<Rating> _ratingRepository;
        IMapper _mapper;
        public RatingService(IRepository<Rating> ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddRatingAsync(RatingModel ratingModel)
        {
            var rating = _mapper.Map<Rating>(ratingModel);

            return await _ratingRepository.AddAsync(rating);
        }

        public async Task<bool> AddRatingsAsync(IEnumerable<RatingModel> ratingsModel)
        {
            var ratingList = _mapper.Map<List<Rating>>(ratingsModel);

            return await _ratingRepository.AddRangeAsync(ratingList);
        }

        public async Task<bool> DeleteRatingAsync(string id)
        {
            return await _ratingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RatingModel>> GetAllRatingsAsync()
        {
            var ratings = await _ratingRepository.GetAllAsync();

            return _mapper.Map<List<RatingModel>>(ratings);
        }

        public async Task<RatingModel> GetRatingByIdAsync(string id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id);

            if (rating == null)
                return null;

            return _mapper.Map<RatingModel>(rating);
        }

        public async Task<bool> UpdateRating(RatingModel ratingModel, string id)
        {
            var rating = _mapper.Map<Rating>(ratingModel);

            return await _ratingRepository.Update(rating);
        }
    }
}
