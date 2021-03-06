﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Fast_Do.Models;
using Fast_Do.Views;
using Fast_Do.Services;

namespace Fast_Do.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Navegar";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
            });

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "RemoveItem", async (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = new AccessItem().SelectAll();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}