using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ProductServices.Core.Interfaces;
using ProductServices.Core.Services;
using DB.Interfaces;
using DB.Repositories;

namespace DIResolver
{
    public static class DIResolver
    {
        public static void ResolveDI(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ProductContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("ProductConnectionString"), 
                x => x.MigrationsAssembly("DB")));

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IRecomendationService, RecomendationService>();
        }
    }
}
