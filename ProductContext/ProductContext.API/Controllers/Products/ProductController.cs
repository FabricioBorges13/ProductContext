using Microsoft.AspNetCore.Mvc;
using ProductContext.Application.Features.Products;
using ProductContext.Application.Features.Products.Commands;
using ProductContext.Domain.Features.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductContext.API.Controllers.Products
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductAddCommand addCommand)
        {
            return Ok(await _service.AddAsync(addCommand));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long codigo)
        {
            return Ok(await _service.DeleteAsync(codigo));
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductUpdateCommand upsateCommand)
        {
            return Ok(await _service.UpdateAsync(upsateCommand));
        }

        [HttpGet]
        [Route("{codigo:int}")]
        public async Task<ActionResult<Product>> GetById(long codigo)
        {
            return await _service.GetByIdAsync(codigo);
        }
    }
}
