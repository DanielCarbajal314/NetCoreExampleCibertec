using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Requests
{
    public class UpdateProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
