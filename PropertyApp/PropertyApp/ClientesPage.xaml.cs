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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientesPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Clientes> clientes { get; set; }
        public ObservableCollection<Clientes> Clientes { get => clientes; set { clientes = value; RaiseOnPropertyChanged(); } }

        public ClientesPage(int EmId)
        {
            Clientes = new ObservableCollection<Clientes>(GetClientes(EmId));

            InitializeComponent();
            this.BindingContext = this;            
        }

        public List<Clientes> GetClientes(int empid)
        {
            return SqliteManager.GetInstance().Query<Clientes>("Select * from Clientes inner join Empresas where empid =? ", new string[] { empid .ToString()});
        }
        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}