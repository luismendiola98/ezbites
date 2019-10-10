using System.ComponentModel;
using Xamarin.Forms;

namespace ezbites
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
        
            InitializeComponent();
        }
        // handle the clicked event to push the Category Page
        // on top of the navigation stack
        void GetStartedButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CategoryPage());
        }
    }
}
