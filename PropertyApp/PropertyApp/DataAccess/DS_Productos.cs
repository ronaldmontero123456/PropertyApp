using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PropertyApp.DataAccess
{
    public class DS_Productos
    {
        public IList<Productos> GetProductos()
        {
            return SqliteManager.GetInstance().Query<Productos>("select * from Productos");
        }

        public void InsertProducto(Productos prod)
        {
            try
            {
                SqliteManager.GetInstance().InsertOrReplace(prod);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
