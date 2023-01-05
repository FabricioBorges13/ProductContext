using AutoMapper;
using ProductContext.Application.Features.Products.Commands;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.Features.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _repository = productRepository;
        }
        public async Task<bool> AddAsync(ProductAddCommand productAdd)
        {
            var entity = _mapper.Map<Product>(productAdd);
            entity.ValidateManufacturingDate();
            return await _repository.AddAsync(entity);
        }


        public async Task<bool> DeleteAsync(long codigo)
        {
            var entity = await _repository.GetByIdAsync(codigo);

            if (entity != null)
            {
                entity.Delete();
                return await _repository.DeleteAsync(entity);
            }
            return false;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(ProductUpdateCommand productUpdate)
        {
            var entity = _mapper.Map<Product>(productUpdate);
            entity.ValidateManufacturingDate();
            return await _repository.UpdateAsync(entity);
        }

        public async Task<Product> GetByIdAsync(long codigo)
        {
            return await _repository.GetByIdAsync(codigo);
        }
    }
}
