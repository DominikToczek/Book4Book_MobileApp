using System.ComponentModel;
using Xamarin.Forms;
using Book4Book_MobileApp.ViewModels;

namespace Book4Book_MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}