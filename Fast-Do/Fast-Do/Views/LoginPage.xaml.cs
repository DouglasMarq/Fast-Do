using Acr.UserDialogs;
using Fast_Do.ViewModels;
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
        LoginPageViewModel ctx = new LoginPageViewModel();
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = ctx;
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
                await Navigation.PushAsync(new SignUpPage());
            }
        }

        private async void Login_Clicked(object sender, System.EventArgs e)
        {
            var result = await ctx.Login(UserEntry.Text, PassEntry.Text);
            if (result)
            {
                ((App)App.Current).MainPage = new MainPage();
            }
            else
            {
                UserDialogs.Instance.Alert("Credenciais erradas.", "Aviso", "OK");
            }
        }
    }
}