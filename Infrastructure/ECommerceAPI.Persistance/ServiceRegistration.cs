
using ECommerceAPI.Persistance.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Persistence;

namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static  void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
