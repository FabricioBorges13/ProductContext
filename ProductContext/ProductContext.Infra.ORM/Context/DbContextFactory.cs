using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Infra.ORM.Context
{
    public class DbContextFactory : IDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext()
        {
            return new ProductContext();
        }      
    }
}
