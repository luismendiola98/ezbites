using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;
using ezbites.Models;
using ezbites.FoodPrepAPI;

namespace ezbites
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            /*


             //get list of all categories for page 1
             List <CategoryView> categories = api.GetCategories();
             System.Diagnostics.Debug.WriteLine(categories.Count);


             //get list of simple recipe info for page 2
             List<RecipeSimpleView> recipes = api.GetRecipesSimple(19);
             foreach (var rec in recipes)
             {
                 System.Diagnostics.Debug.WriteLine(rec.Name);
             }

             //get Recipe for page 3
             RecipeFullView recipe = api.GetRecipe(9);
             System.Diagnostics.Debug.WriteLine(recipe.RecipeSteps);*/


            InitializeComponent();
        }
        // handle the clicked event to push the Category Page
        // on top of the navigation stack
        async void GetStartedButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage());
        }
    }
}
