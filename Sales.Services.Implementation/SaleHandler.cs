using Sales.Infrastructure.DataPersistency.Interface;
using Sales.Services.DataMapping;
using Sales.Services.Interfaces.Handlers;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Implementation
{
    public class SaleHandler : ISalesHadler
    {
        ISalesUnitOfWork _unitOfWork;

        public SaleHandler(ISalesUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<RegisteredSale> ListAll()
        {
            return this._unitOfWork
                        .SaleRepository
                        .ListAll()
                        .Select(x => x.ToDTO());
        }

        public void Register(NewSale saleToRegister)
        {
            this._unitOfWork.SaleRepository.Create(saleToRegister.ToEntity());
            this._unitOfWork.Commit();
        }
    }
}
