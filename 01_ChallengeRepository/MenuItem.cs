using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeRepository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients{ get; set; }
        public double Price { get; set; }

        public MenuItem(int mealNumber, string mealName, string mealDescription, string ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
