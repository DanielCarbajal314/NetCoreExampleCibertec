using Sales.Domain.Entities;
using Sales.Services.Interfaces.Requests;
using Sales.Services.Interfaces.Responses;
using System;

namespace Sales.Services.DataMapping
{
    public static class ProductExtensions
    {
        public static RegisteredProduct ToDTO(this Product entity)
        {
            return new RegisteredProduct()
            {
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public static Product ToEntity(this NewProduct dto)
        {
            return new Product()
            {
                Description = dto.Description,
                Name = dto.Name,
                Price = dto.Price
            };
        }

        public static void UpdateEntity(this UpdateProduct dto, Product entity)
        {
            entity.Price = dto.Price;
            entity.Description = dto.Description;
        }
    }
}
