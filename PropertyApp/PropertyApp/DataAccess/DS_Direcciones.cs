using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_Direcciones
    {
        public DS_Direcciones(){}

        public List<Direcciones> GetDireccionesByCliid(int cliid)
        {
            return SqliteManager.GetInstance().Query<Direcciones>("select * from direcciones where cliid =? ", new string[] {cliid.ToString() });
        }

    }
}
