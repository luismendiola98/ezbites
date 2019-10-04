using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ezbites
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }
        //handle clicked event for home button
        void HomeToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        void MexicanButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecipeListPage());
        }
        void AppetizersButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecipeListPage());
        }
    }
}