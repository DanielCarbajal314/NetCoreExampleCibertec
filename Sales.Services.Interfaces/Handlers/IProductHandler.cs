using System;
using Sales.Services.Interfaces.Common;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;

namespace Sales.Services.Interfaces
{
    public interface IProductHandler: IBasicCrud<NewProduct,UpdateProduct,RegisteredProduct>
    {
    }
}
