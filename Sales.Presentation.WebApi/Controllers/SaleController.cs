using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Services.Interfaces.Handlers;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;

namespace Sales.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private ISalesHadler _saleHandler;

        public SaleController(ISalesHadler saleHandler)
        {
            this._saleHandler = saleHandler;
        }

        [HttpPost]
        [Route("Create")]
        public void Create(NewSale sale)
        {
            this._saleHandler.Register(sale);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<RegisteredSale>> GetAllSales()
        {
            return await this._saleHandler.ListAll();
        }

    }
}