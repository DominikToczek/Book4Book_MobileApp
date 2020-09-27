using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Book4Book_MobileApp.Models;
using Xamarin.Forms;

namespace Book4Book_MobileApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string author;
        private string category;
        private string city;
        private string description;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(author)
                && !String.IsNullOrWhiteSpace(category)
                && !String.IsNullOrWhiteSpace(city)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                IdTxt = Guid.NewGuid().ToString(),
                Text = Text,
                Author = Author,
                Category = Category,
                City = City,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
