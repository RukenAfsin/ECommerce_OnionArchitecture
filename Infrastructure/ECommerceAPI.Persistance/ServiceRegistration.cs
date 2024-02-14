
using ECommerceAPI.Persistance.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Persistence;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Repositories;
using ECommerceAPI.Infrastructure.Utilities.Helpers.FileHelper;
using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Persistence.Repositories.ProductImage;


namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static  void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Singleton);

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductImageReadRepository,ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository, ProductImageWriteRepository>();

            services.AddScoped<IFileHelper, FileHelperManager>();



            //services.AddScoped<IFileService, FileService>();





        }
    }
}
