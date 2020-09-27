using System;
using System.Diagnostics;
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
        private int userId;

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

        public int UserId
        {
            get => userId;
            set => SetProperty(ref userId, value);
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
                UserId = item.UserID;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnDeleteItem(object obj)
        {
            if (App.CurrentUser == null)
            {
                await Shell.Current.DisplayAlert("Delete", "You must login to delete announcements", "OK");
                return;
            }

            if (userId != App.CurrentUser.ID)
            {
                await Shell.Current.DisplayAlert("Delete", "You are not the owner of this announcement.\n\nCan't delete this announcement", "OK");
                return;
            }

            if (await Shell.Current.DisplayAlert("Delete Confirm", "Are you sure you want to delete this announcement?", "Yes", "No"))
            {
                await DataStore.DeleteItemAsync(Id);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}