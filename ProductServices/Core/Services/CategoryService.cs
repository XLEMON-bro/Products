﻿using AutoMapper;
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

            var guid = string.Empty;

            foreach (var category in categotyList)
            {
                guid = GuidHelper.GenerateGuid();

                while (await _categoryRepository.GetByIdAsync(guid) != null)
                {
                    guid = GuidHelper.GenerateGuid();
                }

                category.CategoryId = guid;
            }

            return await _categoryRepository.AddRangeAsync(categotyList);
        }

        public async Task<bool> AddCategoryAsync(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);

            var guid = GuidHelper.GenerateGuid();

            while (await _categoryRepository.GetByIdAsync(guid) != null)
            {
                guid = GuidHelper.GenerateGuid();
            }

            category.CategoryId = guid;

            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return null;

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<bool> UpdateCategory(CategoryModel categoryModel)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryModel.CategoryId);

            if (category == null)
            {
                return false;
            }

            category.CategoryName = categoryModel.CategoryName;
            category.Description = categoryModel.Description;

            return await _categoryRepository.Update(category);
        }
    }
}
