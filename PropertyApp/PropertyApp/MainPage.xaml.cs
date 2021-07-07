using PropertyApp.Controls.Popup;
using PropertyApp.Models;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PropertyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<Empresas> Empresas => GetEmpresas();

        private List<Empresas> GetEmpresas()
        {
            return new List<Empresas>
            {
                new Empresas { EmpId = 1, EmpNombre = "2162 Patricia Ave, LA", EmpDescripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Empresas { EmpId = 2, EmpNombre = "2162 Patricia", EmpDescripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Empresas { EmpId = 3, EmpNombre = "2162 Patricia AA", EmpDescripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
            };
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new PopupDialogEmpresa(((sender as Xamarin.Forms.View).BindingContext as Empresas).EmpId));
            //var property = (sender as View).BindingContext as Property;
            //await this.Navigation.PushAsync(new DetailsPage(property));
        }
    }
}
