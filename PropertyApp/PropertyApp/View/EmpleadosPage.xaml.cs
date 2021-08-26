using PropertyApp.DataAccess;
using PropertyApp.Models;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpleadosPage : ContentPage, INotifyPropertyChanged
    {

        public new event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveCommand { get; private set; }
        public EmpleadosPage(int Id = -1)
        {
            SaveCommand = new Command(SaveEmpleado);

            InitializeComponent();
            BindingContext = this;
            if (Id != -1)
            {
                EditDescripcion.Text = SqliteManager.GetInstance().Query<Empleados>("select EmpDescripcion from Empleados where ordid = " + Id.ToString() + " ").FirstOrDefault()?.EmpDescripcion;
                EditDescripcion.IsEnabled = false;
                ToolbarItems.Clear();
            }
        }

        private void SaveEmpleado()
        {

            if (string.IsNullOrEmpty(EditDescripcion.Text))
            {
                DisplayAlert("Aviso", "Debe Agregar la descripcion del Empleado", "Aceptar");
                return;
            }

            Empleados empleado = new Empleados()
            {
                EmpDescripcion = EditDescripcion.Text,
            };

            new DS_Empleados().InsertEmpleeado(empleado);
            Navigation.PopAsync(true);
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}