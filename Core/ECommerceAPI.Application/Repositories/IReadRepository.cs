using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    //there is methods should be here which query is start with select
    public interface IReadRepository<T>:IRepository<T>where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking= true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
