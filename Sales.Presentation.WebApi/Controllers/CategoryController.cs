using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Services.Interfaces.Handlers;
using Sales.Services.Interfaces.Responses;

namespace Sales.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryHandler _categoryHandler;

        public CategoryController(ICategoryHandler categoryHandler)
        {
            this._categoryHandler = categoryHandler;
        }

        [HttpGet]
        [Route("All")]
        public IEnumerable<RegisteredCategory> GetAll()
        {
            return this._categoryHandler.ListAll();
        }
    }
}