using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Interfaces.Handlers
{
    public interface ISalesHadler
    {
        void Register(NewSale saleToRegister);
        Task<IEnumerable<RegisteredSale>> ListAll();
    }
}
