using System;
using System.Collections.Generic;
using ezbites.Models;
using Xamarin.Forms;

namespace ezbites
{
    public partial class CategoryPage : ContentPage
    {


        // Populate categoryListView with RecipeCategory
       /* List<RecipeGroup> GetRecipes(string search = null)
        {
            var recipes = List<RecipeGroup>
            {

            };
        } */

        //handle clicked event for home button
        void HomeToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        // handle search
        void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        // handle selected recipe categories
        string recipeCategory;
        void Handle_CategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            recipeCategory = e.SelectedItem as string;
        }
        // handle next page button
        void NextButton_Clicked(object sender, EventArgs e)
        {
            if (recipeCategory != null)
                Navigation.PushAsync(new RecipeListPage(recipeCategory));
            else
                DisplayAlert("Error", "Please select a category", "OK");
        }

        public CategoryPage()
        {
            InitializeComponent();


            categoryListView.ItemsSource = new List<RecipeGroup>
            {
                new RecipeGroup("A","A"){
                    new RecipeCategory { Name = "Appatizers" }
                },
                new RecipeGroup("B", "B"){
                    new RecipeCategory { Name = "Baked" },
                    new RecipeCategory { Name = "Breakfast" }
                },
                new RecipeGroup("C","C"){
                    new RecipeCategory { Name = "Chinese" }
                },
                new RecipeGroup("D","D"){
                    new RecipeCategory { Name = "Dessert" },
                    new RecipeCategory { Name = "Dinner" },
                    new RecipeCategory { Name = "Drink" }
                },/*
                new RecipeGroup("E"){

                },*/
                new RecipeGroup("F","F"){
                    new RecipeCategory { Name = "Fried" }
                },
                new RecipeGroup("G","G"){
                    new RecipeCategory { Name = "Greek" }
                },/*
                new RecipeGroup("H"){
                },*/
                new RecipeGroup("I","I"){
                    new RecipeCategory { Name = "Italian" }
                },
                new RecipeGroup("J","J"){
                    new RecipeCategory { Name = "Japanese" }
                },
                new RecipeGroup("K","K"){
                    new RecipeCategory { Name = "Keto" },
                    new RecipeCategory { Name = "Korean" }
                },
                new RecipeGroup("L","L"){
                    new RecipeCategory { Name = "Lunch" }
                },
                new RecipeGroup("M","M"){
                    new RecipeCategory { Name = "Mexican" }
                },/*
                new RecipeGroup("N"){
                },
                new RecipeGroup("O"){
                },*/
                new RecipeGroup("P","P"){
                    new RecipeCategory { Name = "Pescatarian" }
                },/*
                new RecipeGroup("Q"){
                },
                new RecipeGroup("R"){
                },*/
                new RecipeGroup("S","S"){
                    new RecipeCategory { Name = "Salad" },
                    new RecipeCategory { Name = "Soup" }
                },
                new RecipeGroup("T","T"){
                    new RecipeCategory { Name = "Thai" }
                },/*
                new RecipeGroup("U"){
                },*/
                new RecipeGroup("V","V"){
                    new RecipeCategory { Name = "Vegan" }
                },/*
                new RecipeGroup("W"){
                },
                new RecipeGroup("X"){
                },
                new RecipeGroup("Y"){
                },
                new RecipeGroup("Z"){
                }*/
            };


        }

    }
}