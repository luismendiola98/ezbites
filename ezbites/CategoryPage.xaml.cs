using System;
using System.Collections.Generic;
using ezbites.FoodPrepAPI;
using ezbites.Models;
using Xamarin.Forms;

namespace ezbites
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();

            //get list of all categories
            var api = new FoodPrepRequests("https://foodprepapi.azurewebsites.net/api");
            categoryListView.ItemsSource = api.GetCategories();
        }

        //handle clicked event for home button
        async void HomeToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        // handle selected recipe categories
        async void Handle_CategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            //this.BackgroundColor{ get; "Grey"}
            var recipeCategory = e.SelectedItem as CategoryView;
            await Navigation.PushAsync(new RecipeListPage(recipeCategory.CategoryID));
        }

    }
}