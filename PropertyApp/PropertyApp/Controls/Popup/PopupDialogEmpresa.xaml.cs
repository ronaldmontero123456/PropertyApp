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

        private int EmpId;
        public PopupDialogEmpresa(int empid)
        {
            EmpId = empid;

            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync(true);
            Navigation.PushAsync(new ClientesPage(EmpId));
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync(true);
            Navigation.PushAsync(new AgregarEmpresaPage(EmpId));
        }
    }
}