using SQLite;

namespace PropertyApp.Models
{
    public class Orden
    {
        [PrimaryKey, AutoIncrement]
        public int OrdId { get; set; }
        public int ProId { get; set; }
        public int  EmpId { get; set; }
        [Ignore]
        public string OrdNombre => $"Orden-{ OrdId}";
        public string OrdDescripcion { get; set; }
    }
}
