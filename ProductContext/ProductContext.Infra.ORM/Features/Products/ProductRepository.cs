using Microsoft.EntityFrameworkCore;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Infra.ORM.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        ProductContext.Infra.ORM.Context.ProductContext Context;

        public ProductRepository(ProductContext.Infra.ORM.Context.ProductContext context)
        {
            Context = context;
        }

        public async Task<bool> AddAsync(Product entity)
        {
            Context.Products.Add(entity);
            return await Context.SaveChangesAsync() > 0;            
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(long codigo)
        {
            return await Context.Products.FirstOrDefaultAsync(x => x.Id == codigo);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
