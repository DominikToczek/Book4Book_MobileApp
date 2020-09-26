using Book4Book_MobileApp.Droid;
using Book4Book_MobileApp.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperDroid))]
namespace Book4Book_MobileApp.Droid
{
    public class FileHelperDroid : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}