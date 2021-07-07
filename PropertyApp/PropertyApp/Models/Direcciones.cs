using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Models
{
    public class Direcciones
    {
        [PrimaryKey, AutoIncrement]
        public int DirId { get; set; }
        public int EmpId { get; set; }
        public int CliId { get; set; }
        public string DirCalle { get; set; }
        public string DirSector { get; set; }
        public string DirCiudad { get; set; }
        public string DirPais { get; set; }

    }
}
