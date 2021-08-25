using SQLite;

namespace PropertyApp.Models
{
    public class Orden
    {
        [PrimaryKey, AutoIncrement]
        public int OrdId { get; set; }
        public string OrdDescripcion2 { get; set; }
    }
}
