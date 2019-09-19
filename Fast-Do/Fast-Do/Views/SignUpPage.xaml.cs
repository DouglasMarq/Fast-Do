﻿using Fast_Do.ViewModels;
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
    public partial class SignUpPage : ContentPage
    {
        SignUpPageViewModel ctx = new SignUpPageViewModel();
        public SignUpPage(string user = null, string pass = null)
        {
            InitializeComponent();
            BindingContext = ctx;
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

        private void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            ctx.Register(UserEntry.Text, PassEntry.Text, EmailEntry.Text);
        }
    }
}