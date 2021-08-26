using PropertyApp.DataAccess;
using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosPage : ContentPage
    {
        public ICommand SaveCommand { get; private set; }
        public ProductosPage(int Id = -1)
        {

            SaveCommand = new Command(SaveProducto);

            InitializeComponent();

            if(Id == -1)
            {
                EditDescripcion.Text = SqliteManager.GetInstance().Query<Productos>("select ProDescripcion from Productos where ordid = " + Id.ToString() + " ").FirstOrDefault().ProDescripcion;
                EditDescripcion.IsEnabled = false;
                ToolbarItems.Clear();
            }

        }

        private void SaveProducto()
        {

            Productos producto = new Productos()
            {
                ProDescripcion = EditDescripcion.Text,
            };

            new DS_Productos().InsertProducto(producto);
        }
    }
}