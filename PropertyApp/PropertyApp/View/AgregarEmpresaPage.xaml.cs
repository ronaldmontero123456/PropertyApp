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
    public partial class AgregarEmpresaPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        private ObservableCollection<Clientes> clientes { get; set; }
        public ObservableCollection<Clientes> Clientes { get => clientes; set { clientes = value; RaiseOnPropertyChanged(); } }

        int _EmpId;

        DS_Clientes mycli;
        public AgregarEmpresaPage(int EmpId = -1)
        {
            _EmpId = EmpId;

            mycli = new DS_Clientes();

            Clientes = new ObservableCollection<Clientes>(mycli.GetClientesNotInEmpresa(EmpId));

            SearchCommand = new Command(() =>
            {
                Clientes = new ObservableCollection<Clientes>(mycli.GetClientesNotInEmpresa(EmpId));
            });

            SaveCommand = new Command(SaveEmpresa);

            InitializeComponent();
            BindingContext = this;

            if (_EmpId != -1)
            {
                var empresa = new DS_Empresa().GetEmpresaById(_EmpId);
                if(empresa != null)
                {
                    EditNombreEmpresa.Text = empresa.EmpNombre;
                    EditDescripcionEmpresa.Text = empresa.EmpDescripcion;
                }                
            }
        }

        private void entrysearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Clientes = new ObservableCollection<Clientes>(mycli.GetClientesNotInEmpresa(_EmpId, searchclientes.Text));
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Aviso","Estas Seguro que desesas Asignar este clientes","Aceptar","Cancel");

            if(result)
            {
                new DS_ClientesEmpresas().AsignarCliente(_EmpId, (e.SelectedItem as Clientes).CliId);
            }
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void SaveEmpresa()
        {
            if(string.IsNullOrEmpty(EditNombreEmpresa.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar el nombre de la Empresa", "Aceptar");
                return;
            }

            if(string.IsNullOrEmpty(EditDescripcionEmpresa.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar la descripcion de la Empresa", "Aceptar");
                return;
            }

            var empresa = new Empresas
            {
                EmpNombre = EditNombreEmpresa.Text,
                EmpDescripcion = EditDescripcionEmpresa.Text,
            };


            new DS_Empresa().InsertEmpresa(empresa);
            await Navigation.PopAsync(true);
        }
    }
}