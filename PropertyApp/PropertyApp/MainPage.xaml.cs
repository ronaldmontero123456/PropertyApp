using PropertyApp.Controls.Popup;
using PropertyApp.DataAccess;
using PropertyApp.Models;
using PropertyApp.View;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewerw
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

        }

        public List<Orden> Ordenes => GetOrden();

        private List<Orden> GetOrden()
        {
            return SqliteManager.GetInstance().Query<Orden>("select * from Orden", new string[] { }).ToList();
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new PopupDialogEmpresa(((sender as Xamarin.Forms.View).BindingContext as Orden).OrdId));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmpleadosPage());
        }

        protected override void OnAppearing()
        {

            InitializeComponent();
            BindingContext = this;
            base.OnAppearing();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdenPage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductosPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PopupDialogEmpresa(((sender as Xamarin.Forms.View).BindingContext as Orden).OrdId));
        }
    }
}
