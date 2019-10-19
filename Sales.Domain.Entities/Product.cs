using Sales.Domain.Entities.Common;
using System;

namespace Sales.Domain.Entities
{
    public class Product:TEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
