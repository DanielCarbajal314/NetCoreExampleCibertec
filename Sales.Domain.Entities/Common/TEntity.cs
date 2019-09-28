using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities.Common
{
    public class TEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
