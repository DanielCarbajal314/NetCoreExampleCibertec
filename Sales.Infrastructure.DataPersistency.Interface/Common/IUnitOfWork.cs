using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.DataPersistency.Interface.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
