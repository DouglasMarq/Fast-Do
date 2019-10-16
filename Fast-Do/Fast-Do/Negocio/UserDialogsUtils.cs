using XF.Material.Forms.UI.Dialogs;

namespace Fast_Do.Negocio
{
    public static class UserDialogsUtils
    {
        private static IMaterialModalPage Loading;

        public async static void ShowSnackbar(string title)
        {
            await MaterialDialog.Instance.SnackbarAsync(message: title, msDuration: MaterialSnackbar.DurationLong);
        }

        public async static void ShowAlert(string message, string title = "Aviso", string text = "OK")
        {
            await MaterialDialog.Instance.AlertAsync(message: message,
                                    title: title,
                                    acknowledgementText: text);
        }

        public async static void ShowLoading(string message)
        {
            Loading = await MaterialDialog.Instance.LoadingDialogAsync(message: message);
        }

        public async static void HideLoading()
        {
            await Loading.DismissAsync();
        }

        //@TODO
        public async static void ShowConfirm()
        {

        }
    }
}
