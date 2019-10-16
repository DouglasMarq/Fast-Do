using Fast_Do.Models;
using Fast_Do.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fast_Do.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        public void Logout()
        {
            Device.BeginInvokeOnMainThread(() => ((App)App.Current).MainPage = new NavigationPage(new LoginPage()));
            new AccessLogin().DeleteAll();
        }
    }
}
