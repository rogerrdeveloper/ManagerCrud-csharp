using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductManager.Data;
using ProductManager.Model;

namespace ProductManager.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> BuscarTodos()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel?> BuscarPorId(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Adicionar(ProductModel product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(ProductModel product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task Remover(ProductModel product)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }
}