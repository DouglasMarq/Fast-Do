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

        private async void Register_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserEntry.Text))
            {
                await Navigation.PushAsync(new NavigationPage(new SignUpPage(UserEntry.Text)));
            }
            else if (!string.IsNullOrWhiteSpace(PassEntry.Text))
            {
                await Navigation.PushAsync(new NavigationPage(new SignUpPage(null, PassEntry.Text)));
            }
            else if (!string.IsNullOrWhiteSpace(PassEntry.Text) && !string.IsNullOrWhiteSpace(PassEntry.Text))
            {
                await Navigation.PushAsync(new NavigationPage(new SignUpPage(UserEntry.Text, PassEntry.Text)));
            }
            else
            {
                await Navigation.PushAsync(new NavigationPage(new SignUpPage()));
            }
        }

        private async void Login_Clicked(object sender, System.EventArgs e)
        {
            ((App)App.Current).MainPage = new MainPage();
            //await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}