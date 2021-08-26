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
    public partial class EmpleadosPage : ContentPage
    {
        public ICommand SaveCommand { get; private set; }
        public EmpleadosPage(int Id = -1)
        {
            SaveCommand = new Command(SaveEmpleado);

            InitializeComponent();

            if (Id == -1)
            {
                EditDescripcion.Text = SqliteManager.GetInstance().Query<Empleados>("select EmpDescripcion from Empleados where ordid = " + Id.ToString() + " ").FirstOrDefault().EmpDescripcion;
                EditDescripcion.IsEnabled = false;
                ToolbarItems.Clear();
            }
        }

        private void SaveEmpleado()
        {

            Empleados empleado = new Empleados()
            {
                EmpDescripcion = EditDescripcion.Text,
            };

            new DS_Empleados().InsertEmpleeado(empleado);
        }
    }
}