using PropertyApp.Models;
using System;

namespace PropertyApp.DataAccess
{
    public class DS_ProductosOrden
    {
        public void InsertProductoOrden(ProductosOrden productoorden)
        {
            try
            {
                SqliteManager.GetInstance().Insert(productoorden);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
