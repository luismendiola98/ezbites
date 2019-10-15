using System;
using System.Collections.Generic;
using ezbites.FoodPrepAPI;
using Xamarin.Forms;
using ezbites.Models;

namespace ezbites
{
    public partial class IngredientsStepsPage : ContentPage
    {
        public IngredientsStepsPage(int recipeID)
        {
            InitializeComponent();

            var api = new FoodPrepRequests("https://foodprepapi.azurewebsites.net/api");
            RecipeFullView recipe = api.GetRecipe(recipeID);
            if (recipe == null)
            {
                throw new ArgumentNullException();
            }
            BindingContext = recipe;
        }

        //handle clicked event for home button
        async void HomeToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
