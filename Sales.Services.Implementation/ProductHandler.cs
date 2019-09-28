using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infrastructure.DataContext;
using Sales.Infrastructure.DataPersistency.Interface;
using Sales.Infrastructure.DataPersistency.Interface.Common;
using Sales.Services.DataMapping;
using Sales.Services.Interfaces;
using Sales.Services.Interfaces.Common;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Services.Implementation
{
    public class ProductHandler : IProductHandler
    {
        ISalesUnitOfWork _unitOfWork;

        public ProductHandler(ISalesUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            var productToDelete = this._unitOfWork.ProductRepository.FindById(id);
            this._unitOfWork.ProductRepository.Delete(productToDelete);
            this._unitOfWork.Commit();
        }

        public IEnumerable<RegisteredProduct> ListAll()
        {
            return this._unitOfWork.ProductRepository
                            .ListAll()
                            .Select(x => x.ToDTO());
        }

        public IEnumerable<RegisteredProduct> QueryPage(Page request)
        {
            return this._unitOfWork.ProductRepository
                    .GetPage(new DataPage() {
                        Number = request.Number,
                        Size = request.Size
                    })
                    .Select(x => x.ToDTO());
        }

        public RegisteredProduct Register(NewProduct request)
        {
            var product = request.ToEntity();
            this._unitOfWork.ProductRepository.Create(product);
            this._unitOfWork.Commit();
            return product.ToDTO();
        }

        public RegisteredProduct Update(UpdateProduct request)
        {
            var product = this._unitOfWork.ProductRepository.FindById(request.Id);
            request.UpdateEntity(product);
            this._unitOfWork.ProductRepository.Update(product);
            this._unitOfWork.Commit();
            return product.ToDTO();
        }
    }
}
