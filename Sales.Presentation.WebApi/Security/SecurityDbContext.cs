using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Presentation.WebApi.Security
{
    public class SecurityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
