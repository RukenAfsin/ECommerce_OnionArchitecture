using ECommerceAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using ETicaretAPI.Persistence;

namespace ECommerceAPI.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAPIDbContext>
    {
        public ECommerceAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ECommerceAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
