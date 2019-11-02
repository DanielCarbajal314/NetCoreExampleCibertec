using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities.Common;
using Sales.Infrastructure.DataPersistency.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.DataPersistency.EFImplementation.Common
{
    public class Repository<T> : IRepository<T> where T : TEntity
    {
        private DbContext _db;
        private DbSet<T> _entities;

        public Repository(DbContext db)
        {
            this._db = db;
            this._entities = db.Set<T>();
        }

        public void Create(T entity)
        {
            this._entities.Add(entity);
        }

        public void Delete(T entity)
        {
            this._db.Entry(entity).State = EntityState.Deleted;
        }

        public T FindById(int id)
        {
            return this._entities.Find(id);
        }

        public IEnumerable<T> GetPage(DataPage page)
        {
            return this._entities
                       .Where(x=>!x.Deleted)
                       .Skip((page.Number-1)*page.Size)
                       .Take(page.Size);
        }

        public IEnumerable<T> ListAll()
        {
            return this._entities
                        .Where(x => !x.Deleted)
                        .ToList();
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await this._entities
                             .Where(x => !x.Deleted)
                             .ToListAsync();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> searchExpression)
        {
            return this._entities
                        .Where(x => !x.Deleted)
                        .Where(searchExpression);
        }

        public void Update(T entity)
        {
            this._db.Entry(entity).State = EntityState.Modified;
        }
    }
}
