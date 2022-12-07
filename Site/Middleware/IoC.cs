using BLL.Interface;
using BLL.Service;
using DAL.Base;
using DAL.Interface;
using DAL.Repository;
using Site.Service;

namespace Site.Middelwors
{
    public static class Ioc
    {

        public static IServiceCollection AddDependency(IServiceCollection services)
        {


            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddScoped<IJwtService, JwtService>();

            #region Reposritories 
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion


            #region Services 
            services.AddScoped<IUserService, UserService>();
            #endregion

            return services;
        }

    }
}
