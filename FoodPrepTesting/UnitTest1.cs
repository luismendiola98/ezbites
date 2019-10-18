using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodPrepAPICore.Models;
using FoodPrepData.DataModels;
using System.Collections.Generic;

namespace FoodPrepTesting
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void CategoryViewMap_IsMapped()
        {
            var catData = new Category();
            catData.ID = 3;
            catData.Name = "testM";
            catData.Info = "info test.";

            var catView = new CategoryView(catData);
            Assert.AreEqual(catData.ID, catView.CategoryID);
            Assert.AreEqual(catData.Name, catView.Name);
        }

        [TestMethod]
        public void RecipeSimpleViewMap_IsMapped()
        {
            var recipeData = new Recipe();
            recipeData.ID = 14;
            recipeData.Name = "Recipe Test Name";
            recipeData.Info = "Testing info";

            var recSimpleView = new RecipeSimpleView(recipeData);
            Assert.AreEqual(recipeData.ID, recSimpleView.RecipeID);
            Assert.AreEqual(recipeData.Name, recSimpleView.Name);
            Assert.AreEqual(recipeData.Info, recSimpleView.Info);
        }

        [TestMethod]
        public void RecipeFullViewMap_IsMapped()
        {
            var recipeData = new Recipe();
            recipeData.ID = 102;
            recipeData.Name = "Recipe Full test";
            recipeData.Info = "Testing info";
            recipeData.RecipeSteps = "Recipe steps testing";

            var ing = new List<Ingredient>();
            var ing1 = new Ingredient();
            ing1.ID = 3;
            ing1.Info = "ing1 test info";
            ing1.Name = "ing1";
            var ing2 = new Ingredient();
            ing2.ID = 12;
            ing2.Info = "ing2. test.info";
            ing2.Name = " ing2 ";
            ing.Add(ing1);
            ing.Add(ing2);

            var cats = new List<Category>();
            var cat1 = new Category();
            cat1.ID = 2101;
            cat1.Info = "cat1 info test";
            cat1.Name = "cat,1";
            var cat2 = new Category();
            cat2.ID = 12314;
            cat2.Info = "cat2...info...test";
            cat2.Name = ".,.";
            cats.Add(cat1);
            cats.Add(cat2);

            var recFullVIew = new RecipeFullView(recipeData, ing, cats);

            Assert.IsTrue(ing.Count == 2);
            Assert.IsTrue(cats.Count == 2);

            Assert.AreEqual(recipeData.ID, recFullVIew.RecipeID);
            Assert.AreEqual(recipeData.Info, recFullVIew.Info);
            Assert.AreEqual(recipeData.Name, recFullVIew.Name);
            Assert.AreEqual(recipeData.RecipeSteps, recFullVIew.RecipeSteps);

            Assert.AreEqual(ing[0].ID, recFullVIew.Ingredients[0].ID);
            Assert.AreEqual(ing[0].Info, recFullVIew.Ingredients[0].Info);
            Assert.AreEqual(ing[0].Name, recFullVIew.Ingredients[0].Name);

            Assert.AreEqual(ing[1].ID, recFullVIew.Ingredients[1].ID);
            Assert.AreEqual(ing[1].Info, recFullVIew.Ingredients[1].Info);
            Assert.AreEqual(ing[1].Name, recFullVIew.Ingredients[1].Name);

            Assert.AreEqual(cats[0].ID, recFullVIew.Categories[0].ID);
            Assert.AreEqual(cats[0].Info, recFullVIew.Categories[0].Info);
            Assert.AreEqual(cats[0].Name, recFullVIew.Categories[0].Name);

            Assert.AreEqual(cats[1].ID, recFullVIew.Categories[1].ID);
            Assert.AreEqual(cats[1].Info, recFullVIew.Categories[1].Info);
            Assert.AreEqual(cats[1].Name, recFullVIew.Categories[1].Name);
        }
    }
}
