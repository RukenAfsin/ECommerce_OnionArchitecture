
using ECommerceAPI.Application.Security.Token;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Infrastructure.enums;
using ECommerceAPI.Infrastructure.Security.Token;
using ECommerceAPI.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure
{
   public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            //serviceCollection.AddScoped<IFileService ,FileService>();
        }
        //public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        //{
        //    serviceCollection.AddScoped<IStorage, T>();
        //}

        //public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        //{
        //    switch (storageType)
        //    {
        //        case StorageType.Local:
        //            serviceCollection.AddScoped<IStorage, LocalStorage>();
        //            break; 
        //        default:
        //            serviceCollection.AddScoped<IStorage, LocalStorage>();
        //            break;
        //    }
        //}
    }
}
