using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Model;
using ProductManager.Service;

namespace PersonCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService services) {
            service = services;
        }

        [HttpGet]
        public async Task <ActionResult<List<ProductModel>>> BuscarTodos()
        {
            var products = await service.BuscarTodos();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id) 
        { 
            var productId = await service.BuscarPorId(id);

            if (productId == null)
            {
                return NotFound();
            }
            return Ok(productId);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProductModel product)
        {
            var newProduct = await service.Criar(product);
            return CreatedAtAction(
                nameof(BuscarPorId), 
                new { id = newProduct.Id },
                newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, ProductModel product)
        {
            var updated = await service.Atualizar(id, product);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var deleted = await service.Remover(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
