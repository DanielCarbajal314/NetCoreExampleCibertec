using Sales.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class Category : TEntity
    {
        public string Name { get; set; }
        HashSet<Product> Products { get; set; }
    }
}
