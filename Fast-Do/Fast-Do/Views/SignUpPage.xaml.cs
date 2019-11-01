using Acr.UserDialogs;
using Fast_Do.Negocio;
using Fast_Do.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace Fast_Do.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpPageViewModel ctx = new SignUpPageViewModel();
        public SignUpPage(string user = null, string pass = null)
        {
            InitializeComponent();
            BindingContext = ctx;
            Title = "Registro";
            if (!string.IsNullOrWhiteSpace(user))
            {
                ctx.User = user;
                ctx.Pass = null;
            }
            else if (!string.IsNullOrWhiteSpace(pass))
            {
                ctx.User = null;
                ctx.Pass = pass;
            }
            else if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass))
            {
                ctx.User = user;
                ctx.Pass = pass;
            }
            else
            {
                ctx.User = null;
                ctx.Pass = null;
            }
        }

        private async void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            await UserDialogsUtils.ShowLoading("Registrando conta...");
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            Task.Run(async () =>
            {
                var result = await ctx.Register(UserEntry.Text, PassEntry.Text, EmailEntry.Text);
                if (result)
                {
                    await UserDialogsUtils.HideLoading();
                    await UserDialogsUtils.ShowSnackbar("Conta criada com sucesso.");
                    Navigation.PopAsync();
                }
                else
                {
                    await UserDialogsUtils.HideLoading();
                    await UserDialogsUtils.ShowSnackbar("Conta já existe.");
                }
            });
#pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
        }
    }
}