namespace ProductManager.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }




    /*
     No spring boot 

    @Entity
    public class Produto {

    @Id
    @GeneratedValue
    private Long id;

    private String nome;
    private BigDecimal preco;
}
     */
}
