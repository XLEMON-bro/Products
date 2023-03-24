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
    public class ProductService : IProductService
    {
        IProductRepository<Product> _productRepository;
        IMapper _mapper;
        public ProductService(IProductRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddProductAsync(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);

            return await _productRepository.AddAsync(product);
        }

        public async Task<bool> AddProductsAsync(IEnumerable<ProductModel> productsModel)
        {
            var productList = _mapper.Map<List<Product>>(productsModel);

            return await _productRepository.AddRangeAsync(productList);
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<IEnumerable<ProductModel>> GetPaginatedProductsAsync(int pageIndex, int pageSize)
        {
            var produts = await _productRepository.GetPaginatedAsync(pageIndex, pageSize);

            return _mapper.Map<List<ProductModel>>(produts);
        }

        public async Task<ProductModel> GetProductByIdAsync(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductModel>(product);
        }

        public bool UpdateProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);

            return _productRepository.Update(product);
        }
    }
}
