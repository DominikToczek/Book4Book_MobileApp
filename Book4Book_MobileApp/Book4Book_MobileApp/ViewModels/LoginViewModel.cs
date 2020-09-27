using Book4Book_MobileApp.Models;
using Book4Book_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Book4Book_MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string login;
        private string password;

        public Command LoginCommand { get; }
        public Command LoginGuestCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            LoginGuestCommand = new Command(OnLoginGuestClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async void OnLoginClicked(object obj)
        {
            var userList = await App.LocalDatabase.GetAll<User>();
            var user = new User() { Login = Login, Password = Password };

            if (userList.Any(e => e.Login == user.Login && e.Password == user.Password))
            {
                App.CurrentUser = user;
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Login", "Invalid credentials.", "OK");
            }
        }

        private async void OnLoginGuestClicked(object obj)
        {
            App.CurrentUser = null;
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            var user = new User() { Login = Login, Password = Password };

            await App.LocalDatabase.SaveItem(user);
            await Shell.Current.DisplayAlert("Register", "New user has been registered.", "OK");
            App.CurrentUser = user;

            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
