using Book4Book_MobileApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book4Book_MobileApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await App.LocalDatabase.SaveItem(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.IdTxt == item.IdTxt).FirstOrDefault();
            await App.LocalDatabase.DeleteItem(oldItem);
            await App.LocalDatabase.SaveItem(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.IdTxt == id).FirstOrDefault();
            await App.LocalDatabase.DeleteItem(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IdTxt == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            items = await App.LocalDatabase.GetAll<Item>();
            return await Task.FromResult(items);
        }
    }
}