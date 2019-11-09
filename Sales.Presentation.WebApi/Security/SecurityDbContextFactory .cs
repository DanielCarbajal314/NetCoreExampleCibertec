using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Presentation.WebApi.Security
{
    public class SecurityDbContextFactory : IDesignTimeDbContextFactory<SecurityDbContext>
    {
        // Add-Migration Initial -Context SecurityDbContext
        // Update-Database -Context SecurityDbContext
        public SecurityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SecurityDbContext>();
            optionsBuilder.UseSqlServer("data source=.;initial catalog=SalesDBCoreSecurity;user id=sa;password=sql;");

            return new SecurityDbContext(optionsBuilder.Options);
        }
    }
}
