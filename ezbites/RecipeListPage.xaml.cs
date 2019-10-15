using System;
using ezbites.FoodPrepAPI;
using Xamarin.Forms;
using ezbites.Models;

namespace ezbites
{
    public partial class RecipeListPage : ContentPage
    {

        public RecipeListPage(int categoryID)
        {
            InitializeComponent();

            var api = new FoodPrepRequests("https://foodprepapi.azurewebsites.net/api");
            //this.categoryID = categoryID;
            // if there are no recipes for the categoryID chosen
            if(api.GetRecipesSimple(categoryID)== null)
            {
                DisplayAlert("Error", "No recipes found", "OK");
            }
            else
            {
                recipeListView.ItemsSource = api.GetRecipesSimple(categoryID);
            }


        }
        // handle recipe selected
        async void Handle_RecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var recipe = e.SelectedItem as RecipeSimpleView;
            await Navigation.PushAsync(new IngredientsStepsPage(recipe.RecipeID));
        }
        //handle clicked event for home button
        async void HomeToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
