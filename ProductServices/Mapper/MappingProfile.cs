using AutoMapper;
using DB.Models;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel,Category>();
            CreateMap<Category, CategoryModel>();

            CreateMap<LikeModel, Like>();
            CreateMap<Like, LikeModel>();

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<RatingModel, Rating>();
            CreateMap<Rating, RatingModel>();

            CreateMap<ViewModel, View>();
            CreateMap<View, ViewModel>();
        }
    }
}
