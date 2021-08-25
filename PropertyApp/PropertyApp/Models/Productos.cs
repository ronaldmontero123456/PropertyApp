using SQLite;

namespace PropertyApp.Models
{
    public class Productos
    {
        [PrimaryKey, AutoIncrement]
        public int ProId { get; set; }
        public string ProDescripcion { get; set; }
    }
}
