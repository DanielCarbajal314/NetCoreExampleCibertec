using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infrastructure.DataPersistency.EFImplementation.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.DataPersistency.EFImplementation.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository<Product>
    {
        public ProductRepository(DbContext db) : base(db)
        {
        }
    }
}
