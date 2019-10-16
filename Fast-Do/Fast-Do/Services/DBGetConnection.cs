using SQLite;
using System.IO;
using Xamarin.Forms;

namespace Fast_Do.Services
{
    public class DBGetConnection
    {
        public static SQLiteConnection GetConnection()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return new SQLiteConnection(Path.Combine(Directory.CreateDirectory(Path.Combine(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library"), "Database")).FullName, "Items_iOS.db3"));
                case Device.Android:
                    return new SQLiteConnection(Path.Combine(Directory.CreateDirectory(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Database")).FullName, "Items_ANDROID.db3"));
                default:
                    return null;
            }
        }
    }
}
