using Sales.Infrastructure.DataPersistency.Interface;
using Sales.Services.DataMapping;
using Sales.Services.Interfaces.Handlers;
using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Implementation
{
    public class CategoryHandler : ICategoryHandler
    {
        ISalesUnitOfWork _unitOfWork;

        public CategoryHandler(ISalesUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public IEnumerable<RegisteredCategory> ListAll()
        {
            return this._unitOfWork.CategoryRepository
                        .ListAll()
                        .Select(x => x.ToDTO());
        }
    }
}
