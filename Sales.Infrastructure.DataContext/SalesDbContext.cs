using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using System;

namespace Sales.Infrastructure.DataContext
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public SalesDbContext(DbContextOptions<SalesDbContext> options): base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
