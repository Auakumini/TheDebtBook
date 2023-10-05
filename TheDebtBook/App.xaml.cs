using TheDebtBook.Data;

namespace TheDebtBook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeDatabaseAsync();
            MainPage = new AppShell();
        }

        private async void InitializeDatabaseAsync()
        {
            await DataBaseHelper.InitializeDatabaseAsync();
        }

    }
}