using Sales.Domain.Entities.Common;
using Sales.Infrastructure.DataPersistency.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sales.Infrastructure.DataPersistency.Interface.Common
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        IQueryable<T> Search(Expression<Func<T,bool>> searchExpression);
        void Delete(T entity);
        void Update(T entity);
        void Create(T entity);
        IEnumerable<T> ListAll();
        Task<IEnumerable<T>> ListAllAsync();
        IEnumerable<T> GetPage(DataPage page);
    }
}
