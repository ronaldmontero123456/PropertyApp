using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_Clientes
    {
        public DS_Clientes(){}

        public List<Clientes> GetClientesNotInEmpresa(int EmpId)
        {
            return EmpId > 0 ? SqliteManager.GetInstance().Query<Clientes>($@"select CliNombre from Clientes where cliid not in (select cliid from ClientesEmpresas
                                                      where empid = {EmpId} )" , new string []{ }) : SqliteManager.GetInstance().Query<Clientes>($@"select *
                                                      from Clientes", new string[] { });
        }
        public List<Clientes> GetClientesNotInEmpresa(int EmpId, string DesCripcion)
        {
            return EmpId > 0 ? SqliteManager.GetInstance().Query<Clientes>($@"select CliNombre from Clientes where cliid not in (select cliid from ClientesEmpresas
                                                      where empid = {EmpId} ) {(!string.IsNullOrEmpty(DesCripcion)? "and CliNombre like '%{DesCripcion}%'" : "") } " 
                                                      , new string []{ }) : SqliteManager.GetInstance().Query<Clientes>($@"select * from Clientes
                                                      {(!string.IsNullOrEmpty(DesCripcion) ? "where CliNombre like '%{DesCripcion}%'" : "") }", new string[] { });
        }

    }
}
