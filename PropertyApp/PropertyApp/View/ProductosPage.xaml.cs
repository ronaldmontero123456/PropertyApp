using PropertyApp.DataAccess;
using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveCommand { get; private set; }
        public ProductosPage(int Id = -1)
        {

            SaveCommand = new Command(SaveProducto);

            InitializeComponent();
            BindingContext = this;
            if(Id != -1)
            {
                EditDescripcion.Text = SqliteManager.GetInstance().Query<Productos>("select ProDescripcion from Productos where ordid = " + Id.ToString() + " ").FirstOrDefault().ProDescripcion;
                EditDescripcion.IsEnabled = false;
                ToolbarItems.Clear();
            }

        }

        private void SaveProducto()
        {

            if(string.IsNullOrEmpty(EditDescripcion.Text))
            {
                DisplayAlert("Aviso", "Debe Agregar la descripcion del producto", "Aceptar");
                return;
            }

            Productos producto = new Productos()
            {
                ProDescripcion = EditDescripcion.Text,
            };

            new DS_Productos().InsertProducto(producto);
            Navigation.PopAsync(true);
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}