using System.Threading.Tasks;
using XF.Material.Forms.UI.Dialogs;

namespace Fast_Do.Negocio
{
    public static class UserDialogsUtils
    {
        private static IMaterialModalPage Loading;

        public async static Task ShowSnackbar(string title)
        {
            await Task.Run(async () => await MaterialDialog.Instance.SnackbarAsync(message: title, msDuration: MaterialSnackbar.DurationLong));
            Task.FromResult<object>(null);
        }

        public async static Task ShowAlert(string message, string title = "Aviso", string text = "OK")
        {
            await Task.Run(async () =>  await MaterialDialog.Instance.AlertAsync(message: message,
                                    title: title,
                                    acknowledgementText: text));
            Task.FromResult<object>(null);
        }

        public async static Task ShowLoading(string message)
        {
            await Task.Run(async () => Loading = await MaterialDialog.Instance.LoadingDialogAsync(message: message));
            Task.FromResult<object>(null);
        }

        public async static Task HideLoading()
        {
            await Task.Run(async () => await Loading.DismissAsync());
            Task.FromResult<object>(null);
        }

        //@TODO
        public async static Task ShowConfirm()
        {

        }
    }
}
