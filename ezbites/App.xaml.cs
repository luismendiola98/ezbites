using Xamarin.Forms;

namespace ezbites
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //main page is set to a navigation page to navigate between pages
            MainPage = new NavigationPage(new MainPage());
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
