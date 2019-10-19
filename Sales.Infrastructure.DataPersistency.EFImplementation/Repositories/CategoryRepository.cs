using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infrastructure.DataPersistency.EFImplementation.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.DataPersistency.EFImplementation.Repositories
{
    class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }
    }
}
