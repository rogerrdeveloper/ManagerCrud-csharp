using Microsoft.EntityFrameworkCore;
using ProductManager.Model;

namespace ProductManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //representa a coleção/tabela de produtos que o EF Core vai trabalhar.
        public DbSet<ProductModel> Products { get; set; }

        /*No spring boot seria algo:
         * 
         * @Repository
        public interface ProdutoRepository
        extends JpaRepository<Produto, Long> {
}
        */
    }
}
