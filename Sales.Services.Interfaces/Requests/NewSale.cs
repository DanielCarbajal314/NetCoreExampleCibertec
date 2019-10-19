using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Requests
{
    public class NewSale
    {
        public string Client { get; set; }
        public IEnumerable<NewSaleDetail> SaleDetails { get; set; }
    }

    public class NewSaleDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
