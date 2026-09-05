using ProductManager.Model;
using ProductManager.Repository;

namespace ProductManager.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Atualizar(int id, ProductModel product)
        {
            ProductModel productUpdate = await repository.BuscarPorId(id);
            if (productUpdate == null)
            {
                return false;
            }
            if (product.Preco < 0)
            {
                throw new ArgumentException("O preço do produto não pode ser negativo.");
            }
            // Atualize as propriedades do produto
            productUpdate.Nome = product.Nome;
            productUpdate.Preco = product.Preco;

            await repository.Atualizar(productUpdate);
            return true;
        }

        public async Task<ProductModel?> BuscarPorId(int id)
        {
            return await repository.BuscarPorId(id);
        }

        public async Task<List<ProductModel>> BuscarTodos()
        { 
            return await repository.BuscarTodos();
        }

        public async Task<ProductModel> Criar(ProductModel product)
        {
           if (product.Preco < 0)
            {
                throw new ArgumentException("O preço do produto não pode ser igual ou menor que zero.");
            }
            await repository.Adicionar(product);
            return product;
        }

        public async Task<bool> Remover(int id)
        {
            var product = await repository.BuscarPorId(id);
            if (product == null)
            {
                return false;
            }
            await repository.Remover(product);
            return true;
        }
    }
}
