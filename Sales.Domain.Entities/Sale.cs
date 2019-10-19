using Sales.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class Sale : TEntity
    {
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
        public double TotalCost { get; set; }
    }
}
