using Fast_Do.Negocio;
using Fast_Do.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

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

        private void Register_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserEntry.Text))
            {
                Navigation.PushAsync(new NavigationPage(new SignUpPage(UserEntry.Text)));
            }
            else if (!string.IsNullOrWhiteSpace(PassEntry.Text))
            {
                Navigation.PushAsync(new NavigationPage(new SignUpPage(null, PassEntry.Text)));
            }
            else if (!string.IsNullOrWhiteSpace(PassEntry.Text) && !string.IsNullOrWhiteSpace(PassEntry.Text))
            {
                Navigation.PushAsync(new NavigationPage(new SignUpPage(UserEntry.Text, PassEntry.Text)));
            }
            else
            {
                Navigation.PushAsync(new SignUpPage());
            }
        }

        private async void Login_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserEntry.Text) || (!string.IsNullOrWhiteSpace(PassEntry.Text)))
            {
                //await UserDialogsUtils.ShowLoading("Carregando...");
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
                Device.BeginInvokeOnMainThread(() => ((App)App.Current).MainPage = new MainPage());
                //Task.Run(async () =>
                //{
                //    var result = await ctx.Login(UserEntry.Text, PassEntry.Text);
                //    if (result)
                //    {
                //        await UserDialogsUtils.HideLoading();
                //        Device.BeginInvokeOnMainThread(() => ((App)App.Current).MainPage = new MainPage()); 
                //    }
                //    else
                //    {
                //        await UserDialogsUtils.HideLoading();
                //        await UserDialogsUtils.ShowSnackbar("Credenciais erradas.");
                //    }
                //});
#pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            }
            else
            {
                await UserDialogsUtils.ShowSnackbar("Campo de Login e/ou Senha vazia(o).");
            }
        }
    }
}