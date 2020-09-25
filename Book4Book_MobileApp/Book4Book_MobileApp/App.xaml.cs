using Xamarin.Forms;
using Book4Book_MobileApp.Services;
using Book4Book_MobileApp.Database;
using Book4Book_MobileApp.Interfaces;

namespace Book4Book_MobileApp
{
    public partial class App : Application
    {
        private static LocalDatabase localDatabase;
        public static LocalDatabase LocalDatabase
        {
            get
            {
                if (localDatabase == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var path = fileHelper.GetLocalFilePath("CarInfo.database");
                    localDatabase = new LocalDatabase(path);
                }
                return localDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
