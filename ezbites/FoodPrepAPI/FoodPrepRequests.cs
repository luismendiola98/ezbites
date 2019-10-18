using System.Collections.Generic;
using Newtonsoft.Json;
using ezbites.Models;

namespace ezbites.FoodPrepAPI
{
    public class FoodPrepRequests
    {
        public string BaseURL { get; set; }
        public FoodPrepRequests(string baseURL)
        {
            BaseURL = baseURL;
        }

        public List<CategoryView> GetCategories()
        {
            var api = new APICaller();
            string resource = $"CategoryView";

            string res = api.GET($"{BaseURL}/{resource}");
            var Categories = JsonConvert.DeserializeObject<List<CategoryView>>(res);

            return Categories;
        }

        public RecipeFullView GetRecipe(int id)
        {
            var api = new APICaller();
            string resource = $"RecipeView/{id}";

            string res = api.GET($"{BaseURL}/{resource}");
            var recipe = JsonConvert.DeserializeObject<RecipeFullView>(res);
            return recipe;
        }

        public List<RecipeSimpleView> GetRecipesSimple(int categoryID)

        {
            var api = new APICaller();
            string resource = $"RecipeSimple/{categoryID}";

            string res = api.GET($"{BaseURL}/{resource}");
          
            var recipes = JsonConvert.DeserializeObject<List<RecipeSimpleView>>(res);
            return recipes;
        }

        public List<RecipeSimpleView> PostForRecipes(List<int> categoryIDs)
        {
            var api = new APICaller();
            string resource = $"RecipeView";
            string json = JsonConvert.SerializeObject(categoryIDs);

            string res = api.Post($"{BaseURL}/{resource}", json);
            var recipes = JsonConvert.DeserializeObject<List<RecipeSimpleView>>(res);
            return recipes;
        }
    }
}
