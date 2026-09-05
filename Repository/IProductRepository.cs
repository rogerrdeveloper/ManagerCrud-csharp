using ProductManager.Model;

namespace ProductManager.Repository
{
    public interface IProductRepository
    {
        Task Adicionar(ProductModel product);
        Task Atualizar(ProductModel productUpdate);
        Task<ProductModel?> BuscarPorId(int id);
        Task<List<ProductModel>> BuscarTodos();
        Task Remover(ProductModel product);

        public interface IProdutoRepository
        {
            Task<List<ProductModel>> BuscarTodos();

            Task<ProductModel?> BuscarPorId(int id);

            Task Adicionar(ProductModel product);

            Task Atualizar(ProductModel product);

            Task Remover(ProductModel product);
        }
    }
}
