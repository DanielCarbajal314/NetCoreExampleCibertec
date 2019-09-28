using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Responses
{
    public class RegisteredProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
