using SQLite;

namespace PropertyApp.Models
{
    public class ProdcutosOrden
    {
        [PrimaryKey, AutoIncrement]
        public int ProOrdId { get; set; }
        public int ProId { get; set; }
        public int OrdId { get; set; }
    }
}
