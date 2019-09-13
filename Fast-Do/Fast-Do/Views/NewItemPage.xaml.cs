using System;
using System.ComponentModel;
using Xamarin.Forms;

using Fast_Do.Models;
using Fast_Do.Services;
using Acr.UserDialogs;
using System.Collections.Generic;

namespace Fast_Do.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        List<string> Colors = new List<string>()
        {
            "#55efc4",
            "#4cd137",
            "#fbc531",
            "#00cec9",
            "#9c88ff",
            "#0097e6",
            "#c56cf0",
            "#18dcff",
            "#7158e2",
            "#4b4b4b"
        };

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private string pickColor()
        {
            var random = new Random();
            return Colors[random.Next(Colors.Count)];
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                UserDialogs.Instance.Alert("Campo Título está vazio", "Aviso", "OK");
            }
            else if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                UserDialogs.Instance.Alert("Campo Anotação está vazio", "Aviso", "OK");
            }
            else
            {
                Item item = new Item
                {
                    Id = new AccessItem().Count() + 1,
                    Text = txtTitle.Text,
                    Description = txtDesc.Text,
                    Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"),
                    BoxColor = pickColor()

                };
                new AccessItem().Insert(item);
                await Navigation.PopModalAsync();
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}