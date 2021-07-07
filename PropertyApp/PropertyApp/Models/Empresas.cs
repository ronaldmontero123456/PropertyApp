using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Models
{
    public class Empresas
    {
        [PrimaryKey, AutoIncrement]
        public int EmpId { get; set; }
        public string EmpNombre { get; set; }
        public string EmpDescripcion { get; set; }

    }
}
