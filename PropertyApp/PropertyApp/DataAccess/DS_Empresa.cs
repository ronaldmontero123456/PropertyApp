using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_Empresa
    {
        public DS_Empresa(){}

        public void InsertEmpresa(Empresas empresa)
        {
            try
            {
                SqliteManager.GetInstance().Insert(empresa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Empresas GetEmpresaById(int id)
        {
           return SqliteManager.GetInstance().Query<Empresas>("select * from empresas where empid =? ", new string[] { id.ToString()}).FirstOrDefault();
        }

    }
}
