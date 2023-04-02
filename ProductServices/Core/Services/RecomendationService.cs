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
    //59bf4730-6538-4f32-b7d1-918b1a4ad93c - id for text item from db
    public class RecomendationService : IRecomendationService
    {
        IRecomendationRepository _recomendationRepository;
        IMapper _mapper;
        public RecomendationService(IRecomendationRepository recomendationRepository, IMapper mapper)
        {
            _recomendationRepository = recomendationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetMostLikedTodayProducts()
        {
            var products = await _recomendationRepository.GetMostLikedTodayProducts();

            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<IEnumerable<ProductModel>> GetMostLikedTodayProductsByCategory(string categoryId)
        {
            var products = await _recomendationRepository.GetMostLikedTodayProductsByCategory(categoryId);

            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<IEnumerable<ProductModel>> GetMostViewedTodayProducts()
        {
            var products = await _recomendationRepository.GetMostViewedTodayProducts();

            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<IEnumerable<ProductModel>> GetMostViewedTodayProductsByCategory(string categoryId)
        {
            var products = await _recomendationRepository.GetMostViewedTodayProductsByCategory(categoryId);

            return _mapper.Map<List<ProductModel>>(products);
        }
    }
}
