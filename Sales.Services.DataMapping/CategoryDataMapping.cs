using Sales.Domain.Entities;
using Sales.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.DataMapping
{
    public static class CategoryDataMapping
    {
        public static RegisteredCategory ToDTO(this Category category)
        {
            return new RegisteredCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
