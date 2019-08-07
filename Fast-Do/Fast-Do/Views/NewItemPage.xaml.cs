using System;
using System.ComponentModel;
using Xamarin.Forms;

using Fast_Do.Models;
using Fast_Do.Services;

namespace Fast_Do.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item item = new Item
            {
                Id = new AccessItem().Count() + 1,
                Text = txtTitle.Text,
                Description = txtDesc.Text
            };
            new AccessItem().Insert(item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}