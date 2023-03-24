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
    public class CategoryService : ICategoryService
    {
        IRepository<Category> _categoryRepository;
        IMapper _mapper;
        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoriesAsync(IEnumerable<CategoryModel> categoriesModel)
        {
            var categotyList = _mapper.Map<List<Category>>(categoriesModel);

            return await _categoryRepository.AddRangeAsync(categotyList);
        }

        public async Task<bool> AddCategotyAsync(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);

            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> DeleteCategotyAsync(string id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> GetCategotyByIdAsync(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryModel>(category);
        }

        public bool UpdateCategory(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);

            return _categoryRepository.Update(category);
        }
    }
}
