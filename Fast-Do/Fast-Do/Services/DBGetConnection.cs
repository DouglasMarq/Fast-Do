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
                    var nameDBiOS = "Items_iOS.db3";
                    var personalfolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string libraryfolder = Path.Combine(personalfolder, "..", "Library");
                    var folderiOS = Path.Combine(libraryfolder, "Database");
                    var pathiOS = Directory.CreateDirectory(folderiOS);
                    var pathDBiOS = Path.Combine(pathiOS.FullName, nameDBiOS);

                    return new SQLiteConnection(pathDBiOS);
                case Device.Android:
                    var nameDBANDROID = "Items_ANDROID.db3";
                    var folderANDROID = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Database");
                    var pathANDROID = Directory.CreateDirectory(folderANDROID);
                    var pathDBANDROID = Path.Combine(pathANDROID.FullName, nameDBANDROID);
                    return new SQLiteConnection(pathDBANDROID);
                default:
                    return null;
            }
        }
    }
}
