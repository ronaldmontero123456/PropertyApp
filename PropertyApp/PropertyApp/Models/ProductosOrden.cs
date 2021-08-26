using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Models
{
    public class ProductosOrden
    {
        [PrimaryKey, AutoIncrement]
        public int ProOrdId { get; set; }
        public int ProId { get; set; }
        public int OrdId { get; set; }
    }
}
