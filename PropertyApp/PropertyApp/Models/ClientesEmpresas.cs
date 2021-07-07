using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Models
{
    public class ClientesEmpresas
    {
        [PrimaryKey, AutoIncrement]
        public int CliEmpId { get; set; }
        public int EmpId { get; set; }
        public int ClidId { get; set; }

    }
}
