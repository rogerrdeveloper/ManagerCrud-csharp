using ProductManager.Model;

namespace ProductManager.Service
{
    public interface IProductService
    {
        Task<List<ProductModel>> BuscarTodos();

        Task<ProductModel?> BuscarPorId(int id);

        Task<ProductModel> Criar(ProductModel product);

        Task<bool> Atualizar(int id, ProductModel product);

        Task<bool> Remover(int id);
    }
}
