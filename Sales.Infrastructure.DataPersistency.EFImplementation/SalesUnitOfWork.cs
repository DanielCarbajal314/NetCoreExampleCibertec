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
        public IRepository<Sale> SaleRepository => _saleRepository;
        public IRepository<Category> CategoryRepository => _categoryRepository;

        private SalesDbContext _db;
        private ProductRepository _productRepository;
        private SaleRepository _saleRepository;
        private CategoryRepository _categoryRepository;

        public SalesUnitOfWork(SalesDbContext db)
        {
            this._db = db;
            this._productRepository = new ProductRepository(db);
            this._saleRepository = new SaleRepository(db);
            this._categoryRepository = new CategoryRepository(db);
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
