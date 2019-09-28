using Sales.Domain.Entities;
using Sales.Infrastructure.DataPersistency.Interface.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.DataPersistency.Interface
{
    public interface ISalesUnitOfWork : IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
    }
}
