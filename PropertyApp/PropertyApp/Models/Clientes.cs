using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Models
{
    public class Clientes
    {
        [PrimaryKey,AutoIncrement]
        public int CliId { get; set; }
        public string CliNombre { get; set; }
        public string CliDescripcion { get; set; }
    }
}
