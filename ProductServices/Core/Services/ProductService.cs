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

        public async Task<IEnumerable<ProductModel>> GetPaginatedProductsByCategoryAsync(int pageIndex, int pageSize, string categoryId)
        {
            var produts = await _productRepository.GetPaginatedAsync(pageIndex, pageSize, categoryId);

            return _mapper.Map<List<ProductModel>>(produts);
        }

        public async Task<ProductModel> GetProductByIdAsync(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<bool> UpdateProduct(ProductWithDetailsModel productModel)
        {
            var product = await _productRepository.GetByIdAsync(productModel.ProductId);

            if (product == null)
            {
                return false;
            }

            product.Price = productModel.Price;
            product.Description = productModel.Description;
            product.Name = productModel.Name;
            product.ImageURL = productModel.ImageURL;
            product.CategoryId = productModel.CategoryId;
            product.Category = productModel.Category == null ? product.Category : productModel.Category;
            product.View = productModel.View == null ? product.View : productModel.View;
            product.Like = productModel.Like == null ? product.Like : productModel.Like;
            product.Raiting = productModel.Raiting.Count == 0 ? product.Raiting : productModel.Raiting;

            return await _productRepository.Update(product);
        }

        public async Task<ProductWithDetailsModel> GetProductWithDetailsById(string id)
        {
            var product = await _productRepository.GetProductWithDetails(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductWithDetailsModel>(product);
        }

        public async Task<bool> AddProductWithDetailsAsync(ProductWithDetailsModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);

            return await _productRepository.AddAsync(product);
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int Size, string categoryId)
        {
            var produts = await _productRepository.GetProductsByCategory(Size, categoryId);

            return _mapper.Map<List<ProductModel>>(produts);
        }

    }
}
