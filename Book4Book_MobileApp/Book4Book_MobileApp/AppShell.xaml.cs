using System;
using System.Collections.Generic;
using Book4Book_MobileApp.ViewModels;
using Book4Book_MobileApp.Views;
using Xamarin.Forms;

namespace Book4Book_MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.CurrentUser = null;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
