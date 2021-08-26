using PropertyApp.DataAccess;
using PropertyApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdenPage : ContentPage, INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; private set; }
        private ObservableCollection<Empleados> empleados { get; set; }
        public ObservableCollection<Empleados> Empleados { get => empleados; set { empleados = value; RaiseOnPropertyChanged(); } }

        private Empleados currentempleado { get; set; }
        public Empleados CurrentEmpleado { get => currentempleado; set { currentempleado = value; RaiseOnPropertyChanged(); } }
        private ObservableCollection<Productos> productos { get; set; }
        public ObservableCollection<Productos> Productos { get => productos; set { productos = value; RaiseOnPropertyChanged(); } }

        private Productos currentproducto { get; set; }
        public Productos CurrentProducto { get => currentproducto; set { currentproducto = value; RaiseOnPropertyChanged(); } }

        private int _Id;

        public new event PropertyChangedEventHandler PropertyChanged;
        public OrdenPage(int Id = -1)
        {
            _Id = Id;

            Productos = new ObservableCollection<Productos>(new DS_Productos().GetProductos());

            EditDescripcion.Text = _Id == -1 ? "" : SqliteManager.GetInstance().Query<Productos>("select ProDescripcion from Orden where ordid = " + _Id.ToString() + "").FirstOrDefault().ProDescripcion;

            if (_Id > -1 && Productos != null)
            {
                CurrentProducto = Productos.FirstOrDefault(p => p.OrdId == _Id);
            }

            Empleados = new ObservableCollection<Empleados>(new DS_Empleados().GetEmpleados());


            if (_Id > -1 && Empleados != null)
            {
                CurrentEmpleado = Empleados.FirstOrDefault(e => e.OrdId == _Id);
            }

            SaveCommand = new Command(SaveOrden);

            InitializeComponent();

            BindingContext = this;
        }


        public async void SaveOrden()
        {

            if (string.IsNullOrEmpty(EditDescripcion.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar la descripcion de la Orden", "Aceptar");
                return;
            }

            var orden = new Orden
            {
                ProId = CurrentProducto != null ? CurrentProducto.ProId : -1,
                EmpId = CurrentEmpleado !=  null ? CurrentEmpleado.EmpId : -1,
                OrdDescripcion = EditDescripcion.Text,
            };

            if(CurrentProducto != null)
            {
                CurrentProducto.OrdId = orden.OrdId;
                SqliteManager.GetInstance().Update(CurrentProducto);
            }
            
            if(CurrentEmpleado != null)
            {
                CurrentEmpleado.OrdId = orden.OrdId;
                SqliteManager.GetInstance().Update(CurrentProducto);
            }

            new DS_Orden().InsertOrden(orden);
            await Navigation.PopAsync(true);
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}