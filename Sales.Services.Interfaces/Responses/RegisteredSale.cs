using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Responses
{
    public class RegisteredSale
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}
