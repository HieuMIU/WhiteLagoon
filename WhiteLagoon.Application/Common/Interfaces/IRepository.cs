using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool isTracked = false);

        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool isTracked = false);

        bool Any(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Delete(T entity);
    }
}
