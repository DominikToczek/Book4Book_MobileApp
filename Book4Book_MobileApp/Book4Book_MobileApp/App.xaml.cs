using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Book4Book_MobileApp.Services;
using Book4Book_MobileApp.Views;

namespace Book4Book_MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
