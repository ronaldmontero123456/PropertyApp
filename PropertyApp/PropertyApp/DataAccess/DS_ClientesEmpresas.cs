using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_ClientesEmpresas
    {
        public DS_ClientesEmpresas(){}

        public void AsignarCliente(int empid, int cliid)
        {
            var empresa = new ClientesEmpresas
            { EmpId = empid , ClidId = cliid};

            try
            {
                SqliteManager.GetInstance().Insert(empresa);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }


        }

    }
}
