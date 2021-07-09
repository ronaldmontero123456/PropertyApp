using PropertyApp.DataAccess;
using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AgregarClientePage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveCommand { get; private set; }

        public ObservableCollection<Direcciones> direcciones { get; set; }

        public ObservableCollection<Direcciones> Direcciones { get => direcciones; set { direcciones = value; RaiseOnPropertyChanged(); } }
        public AgregarClientePage(int cliid = -1)
        {
            SaveCommand = new Command(SaveCliente);

            Direcciones = new ObservableCollection<Direcciones>(new DS_Direcciones().GetDireccionesByCliid(cliid));

            InitializeComponent();
        }

        private async void SaveCliente()
        {
            if (string.IsNullOrEmpty(EditNombreCliente.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar el nombre de la Empresa", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(EditDescripcionCliente.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar la descripcion de la Empresa", "Aceptar");
                return;
            }

            var clientes = new Clientes
            {
                CliNombre = EditNombreCliente.Text,
                CliDescripcion = EditDescripcionCliente.Text,
            };
            SqliteManager.GetInstance().Insert(clientes);
            await Navigation.PopAsync(true);
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}