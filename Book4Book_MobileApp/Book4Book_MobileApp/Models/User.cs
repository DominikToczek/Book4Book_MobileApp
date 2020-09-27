using Book4Book_MobileApp.Interfaces;

namespace Book4Book_MobileApp.Models
{
    public class User : ISqlite
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
