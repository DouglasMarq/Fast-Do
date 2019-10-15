using Fast_Do.ViewModels;
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
            if(!string.IsNullOrWhiteSpace(UserEntry.Text) || (!string.IsNullOrWhiteSpace(PassEntry.Text)))
            {
                using (var dialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Carregando..."))
                {
                    var result = await ctx.Login(UserEntry.Text, PassEntry.Text);
                    if (result)
                    {
                        await dialog.DismissAsync();
                        ((App)App.Current).MainPage = new MainPage();
                    }
                    else
                    {
                        await dialog.DismissAsync();
                        await MaterialDialog.Instance.AlertAsync(message: "Credenciais erradas.", title: "Aviso", acknowledgementText: "OK");
                    }
                }
            }
            else
            {
                await MaterialDialog.Instance.AlertAsync(message: "Campo de Login e/ou Senha vazia(o).", title: "Aviso", acknowledgementText: "OK");
            }
        }
    }
}