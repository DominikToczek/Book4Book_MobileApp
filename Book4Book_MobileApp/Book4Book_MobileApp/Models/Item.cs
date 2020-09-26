using Book4Book_MobileApp.Interfaces;
using System;

namespace Book4Book_MobileApp.Models
{
    public class Item : ISqlite
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public string IdTxt { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}