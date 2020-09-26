using Book4Book_MobileApp.Interfaces;

namespace Book4Book_MobileApp.Models
{
    public class Item : ISqlite
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }

        public string IdTxt { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
    }
}