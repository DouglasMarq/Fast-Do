using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fast_Do.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            ((App)App.Current).MainPage = new MainPage();
            //await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}