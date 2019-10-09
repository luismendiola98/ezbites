using System;

using Xamarin.Forms;

namespace ezbites
{
    public partial class RecipeListPage : ContentPage
    {
        public RecipeListPage(string recipeCategory)
        {
            InitializeComponent();


        }

        //handle clicked event for home button
        void HomeToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
