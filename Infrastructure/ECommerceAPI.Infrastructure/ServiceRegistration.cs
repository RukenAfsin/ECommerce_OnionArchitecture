
using ECommerceAPI.Application.Security.Token;
using ECommerceAPI.Application.Services;
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
            serviceCollection.AddScoped<IFileService ,FileService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
