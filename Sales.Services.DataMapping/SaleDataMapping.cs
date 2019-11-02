using Sales.Domain.Entities;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.DataMapping
{
    public static class SaleDataMapping
    {
        public static Sale ToEntity(this NewSale saleToRegister)
        {
            return new Sale()
            {
                Client = saleToRegister.Client,
                Date = DateTime.Now,
                TotalCost = saleToRegister.SaleDetails.Select(x => x.Cost).Sum(),
                SaleDetails = saleToRegister.SaleDetails.Select(x => x.ToEntity()).ToList()
            };
        }

        private static SaleDetail ToEntity(this NewSaleDetail saleDetail)
        {
            return new SaleDetail()
            {
                Cost = saleDetail.Cost,
                ProductId = saleDetail.ProductId,
                Quantity = saleDetail.Quantity,
            };
        }

        public static RegisteredSale ToDTO(this Sale sale)
        {
            return new RegisteredSale()
            {
                Id = sale.Id,
                Client = sale.Client,
                Date = sale.Date,
                Total = sale.TotalCost
            };
        }

    }
}
