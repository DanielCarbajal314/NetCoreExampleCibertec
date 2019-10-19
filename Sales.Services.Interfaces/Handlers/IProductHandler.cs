using System;
using System.Collections;
using System.Collections.Generic;
using Sales.Services.Interfaces.Common;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;

namespace Sales.Services.Interfaces
{
    public interface IProductHandler: IBasicCrud<NewProduct,UpdateProduct,RegisteredProduct>
    {
        IEnumerable<RegisteredProduct> GetByCategoryId(int id);
    }
}
