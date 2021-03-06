using PropertyApp.DataAccess;
using PropertyApp.Models;
using PropertyApp.View;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.Controls.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDialogEmpresa : PopupPage
    {

        private int Id;
        public PopupDialogEmpresa(int id)
        {
            Id = id;

            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync(true);
            Navigation.PushAsync(new EmpleadosPage(Id));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync(true);
            Navigation.PushAsync(new OrdenPage(Id));
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync(true);
            Navigation.PushAsync(new ProductosPage(Id));
        }
    }
}