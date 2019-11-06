﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fast_Do.Services;
using Fast_Do.Views;
using Fast_Do.Models;

namespace Fast_Do
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this, "Material.Configuration");

            if(new AccessLogin().Count() > 0)
            {
                ((App)App.Current).MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
