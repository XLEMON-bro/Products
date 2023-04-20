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

            var guid = GuidHelper.GenerateGuid();

            while(await _productRepository.GetByIdAsync(guid) != null)
            {
                guid = GuidHelper.GenerateGuid();
            }

            product.ProductId = guid;

            return await _productRepository.AddAsync(product);
        }

        public async Task<bool> AddProductsAsync(IEnumerable<ProductModel> productsModel)
        {
            var productList = _mapper.Map<List<Product>>(productsModel);

            var guid = string.Empty;

            foreach(var product in productList)
            {
                guid = GuidHelper.GenerateGuid();

                while (await _productRepository.GetByIdAsync(guid) != null)
                {
                    guid = GuidHelper.GenerateGuid();
                }

                product.ProductId = guid;
            }

            return await _productRepository.AddRangeAsync(productList);
        }

        public async Task<bool> DeleteProductCascadeAsync(string id)
        {
            return await _productRepository.DeleteOnCascadeByID(id);
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
            product.Category = productModel.Category == null ? product.Category : _mapper.Map<Category>(productModel.Category);
            product.View = productModel.View == null ? product.View : _mapper.Map<View>(productModel.View);
            product.Like = productModel.Like == null ? product.Like : _mapper.Map<Like>(productModel.Like);
            product.Raiting = productModel.Raiting.Count == 0 ? product.Raiting : _mapper.Map<List<Rating>>(productModel.Raiting);

            return await _productRepository.Update(product);
        }

        public async Task<ProductWithDetailsModel> GetProductWithDetailsById(string id)
        {
            var product = await _productRepository.GetProductWithDetails(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductWithDetailsModel>(product);
        }

        public async Task<bool> AddProductsWithDetailsAsync(List<ProductWithDetailsModel> productModel)
        {
            var products = _mapper.Map<List<Product>>(productModel);

            foreach (var product in products)
            {
                var guid = GuidHelper.GenerateGuid();

                while (await _productRepository.GetByIdAsync(guid) != null)
                {
                    guid = GuidHelper.GenerateGuid();
                }

                product.ProductId = guid;

                if (product.Category != null)
                {
                    guid = GuidHelper.GenerateGuid();
                    product.Category.CategoryId = guid;
                    product.CategoryId = guid;
                }

                if (product.View != null)
                {
                    product.View.Id = GuidHelper.GenerateGuid();
                    product.View.ProductId = product.ProductId;
                }
                else
                {
                    product.View = new View
                    {
                        Id = GuidHelper.GenerateGuid(),
                        ProductId = product.ProductId
                    };
                }

                if (product.Like != null)
                {
                    product.Like.Id = GuidHelper.GenerateGuid();
                    product.Like.ProductId = product.ProductId;
                }
                else
                {
                    product.Like = new Like
                    {
                        Id = GuidHelper.GenerateGuid(),
                        ProductId = product.ProductId
                    };
                }

                foreach (var rating in product.Raiting)
                {
                    rating.Id = GuidHelper.GenerateGuid();
                    rating.ProductId = product.ProductId;
                }
            }
            return await _productRepository.AddRangeAsync(products);
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int Size, string categoryId)
        {
            var produts = await _productRepository.GetProductsByCategory(Size, categoryId);

            return _mapper.Map<List<ProductModel>>(produts);
        }

    }
}
