using DB.Interfaces;
using DB.Models;
using ProductServices.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Services
{
    //59bf4730-6538-4f32-b7d1-918b1a4ad93c - id for text item from db
    public class RecomendationService : IRecomendationService
    {
        IRepository<Product> _productRepository;
        public RecomendationService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

    }
}
