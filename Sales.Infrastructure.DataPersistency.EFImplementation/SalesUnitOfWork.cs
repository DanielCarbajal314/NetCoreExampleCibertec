using Sales.Domain.Entities;
using Sales.Infrastructure.DataContext;
using Sales.Infrastructure.DataPersistency.EFImplementation.Repositories;
using Sales.Infrastructure.DataPersistency.Interface;
using Sales.Infrastructure.DataPersistency.Interface.Common;
using System;

namespace Sales.Infrastructure.DataPersistency.EFImplementation
{
    public class SalesUnitOfWork : ISalesUnitOfWork
    {
        public IRepository<Product> ProductRepository => _productRepository;

        private SalesDbContext _db;
        private ProductRepository _productRepository;

        public SalesUnitOfWork(SalesDbContext db)
        {
            this._db = db;
            this._productRepository = new ProductRepository(db);
        }

        public void Commit()
        {
            this._db.SaveChanges();
        }

        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
