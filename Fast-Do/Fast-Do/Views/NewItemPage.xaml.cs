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
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item = new Item
            {
                Id = Item.Id + 1,
                Text = txtTitle.Text,
                Description = txtDesc.Text
            };
            new AccessItem().Insert(Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}