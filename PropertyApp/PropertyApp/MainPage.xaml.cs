using PropertyApp.Controls.Popup;
using PropertyApp.DataAccess;
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
            return SqliteManager.GetInstance().Query<Empresas>("select * from empresas", new string[] { });
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new PopupDialogEmpresa(((sender as Xamarin.Forms.View).BindingContext as Empresas).EmpId));
        }
    }
}
