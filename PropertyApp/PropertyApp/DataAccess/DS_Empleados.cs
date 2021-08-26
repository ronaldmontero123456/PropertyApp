
using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_Empleados
    {
        public void InsertEmpleeado(Empleados empleado)
        {
            try
            {
                SqliteManager.GetInstance().InsertOrReplace(empleado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Empleados> GetEmpleados()
        {
            return SqliteManager.GetInstance().Query<Empleados>("select * from Empleados");
        }
    }
}
