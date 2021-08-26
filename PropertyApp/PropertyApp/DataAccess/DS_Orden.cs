using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_Orden
    {
        public void InsertOrden(Orden orden)
        {
            try
            {
                SqliteManager.GetInstance().InsertOrReplace(orden);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
