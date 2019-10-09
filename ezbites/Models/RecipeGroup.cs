using System;
using System.Collections.Generic;

namespace ezbites.Models
{
    public class RecipeGroup : List<RecipeCategory>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public RecipeGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }
    }
}
