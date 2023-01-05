using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Features.Products
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product entity);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long codigo);
        Task<bool> UpdateAsync(Product entity);
        Task<bool> DeleteAsync(Product entity);
    }
}
