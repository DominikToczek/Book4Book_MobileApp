using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Book4Book_MobileApp.Models;
using Book4Book_MobileApp.Views;
using Xamarin.Forms;

namespace Book4Book_MobileApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string author;
        private string category;
        private string city;
        private string description;

        public Command DeleteItemCommand { get; }

        public ItemDetailViewModel()
        {
            DeleteItemCommand = new Command(OnDeleteItem);
        }

        public string Id { get; set; }

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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdTxt;
                Text = item.Text;
                Author = item.Author;
                Category = item.Category;
                City = item.City;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnDeleteItem(object obj)
        {
            if (await Shell.Current.DisplayAlert("Delete Confirm", "Are you sure you want to delete this announcement?", "Yes", "No"))
            {
                await DataStore.DeleteItemAsync(Id);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
