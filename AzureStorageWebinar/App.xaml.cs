using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AzureStorageWebinar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            TabbedPage tabbed = new TabbedPage();
            tabbed.Children.Add(new View.PersonRegistrationPage());
            tabbed.Children.Add(new View.PersonsList());
            MainPage = new View.PersonRegistrationPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
