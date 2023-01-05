using ProductContext.Application.Features.Products.Commands;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.Features.Products
{
    public interface IProductService
    {
        Task<bool> AddAsync(ProductAddCommand entity);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long codigo);
        Task<bool> UpdateAsync(ProductUpdateCommand productUpdate);
        Task<bool> DeleteAsync(long codigo);
    }
}
