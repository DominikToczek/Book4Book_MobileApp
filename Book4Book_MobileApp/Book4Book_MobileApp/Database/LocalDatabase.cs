using Book4Book_MobileApp.Interfaces;
using Book4Book_MobileApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book4Book_MobileApp.Database
{
    public class LocalDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public LocalDatabase(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Item>().Wait();
            database.CreateTableAsync<User>().Wait();
        }

        public async Task<List<T>> GetAll<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();
        }

        public async Task<int> SaveItem<T>(T item) where T : class, ISqlite, new()
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
            {
                result = await database.InsertAsync(item);
            }

            return result;
        }

        public async Task<int> DeleteItem<T>(T item) where T : class, ISqlite, new()
        {
            return await database.DeleteAsync(item);
        }
    }
}
