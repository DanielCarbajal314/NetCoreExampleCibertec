using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Handlers
{
    public interface ICategoryHandler
    {
        IEnumerable<RegisteredCategory> ListAll();
    }
}
