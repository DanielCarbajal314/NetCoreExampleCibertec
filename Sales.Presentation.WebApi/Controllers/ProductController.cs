using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Services.Interfaces;
using Sales.Services.Interfaces.Common;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;

namespace Sales.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductHandler _productHandler;

        public ProductController(IProductHandler productHandler)
        {
            this._productHandler = productHandler;
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            this._productHandler.Delete(id);
        }

        [HttpGet]
        [Route("All")]
        public IEnumerable<RegisteredProduct> ListAll()
        {
            return this._productHandler.ListAll();
        }

        [HttpGet]
        [Route("Page")]
        public IEnumerable<RegisteredProduct> QueryPage([FromQuery]Page request)
        {
            return this._productHandler.QueryPage(request);
        }

        [HttpPost]
        [Route("Create")]
        public RegisteredProduct Register([FromBody]NewProduct request)
        {
            return this._productHandler.Register(request);
        }

        [HttpPut]
        [Route("Update")]
        public RegisteredProduct Update([FromBody]UpdateProduct request)
        {
            return this._productHandler.Update(request);
        }
    }
}