using Sales.Services.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Handlers
{
    public interface ISalesHadler
    {
        void Register(NewSale saleToRegister);
    }
}
