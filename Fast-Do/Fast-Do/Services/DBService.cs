using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Do.Services
{
    public class DBService
    {
        private SQLiteConnection sqliteconnection;

        private const string DbFileName = "Items.db3";

        public void Insert(object obj)
        {
            sqliteconnection.Insert(obj);
        }

        public List<object> SelectAll()
        {
            return (from data in sqliteconnection.Table<object>()
                    select data).ToList();
        }
    }
}
