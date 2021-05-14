using _01_ChallengeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuProgramUI
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedContent();
            MenuAccess();
        }
        private void MenuAccess()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select an option: \n" +
                    "\n1. Add Menu Item\n" +
                    "2. Show Full Menu\n" +
                    "3. Veiw Menu Item by Number\n" +
                    "4. Update Menu Item\n" +
                    "5. Delete Menu Item\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        AddMenuItem();
                        break;
                    case "2":
                    case "two":
                        ShowFullMenu();
                        break;
                    case "3":
                    case "three":
                        ViewMenuItemByNumber();
                        break;
                    case "4":
                    case "four":
                        UpdateMenuItem();
                        break;
                    case "5":
                    case "five":
                        DeleteMenuItem();
                        break;
                    case "6":
                    case "six":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
            }
        }

        private void AddMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();
            //number
            Console.WriteLine("Enter Menu Number:");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            //name
            Console.WriteLine("Enter Meal Name:");
            newItem.MealName = (Console.ReadLine());
            //descrip
            Console.WriteLine("Enter Meal Desription:");
            newItem.MealDescription = (Console.ReadLine());
            //ingr
            Console.WriteLine("Enter Meal Ingredients:");
            newItem.Ingredients = (Console.ReadLine());
            //price
            Console.WriteLine("Enter Meal Price:");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAddedCorrectly = _repo.AddMenuItem(newItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The Meal was added");
            }
            else
            {
                Console.WriteLine("Could not add the Meal.");
            }

        }

        private void ShowFullMenu()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetMenu();
            foreach (MenuItem item in fullMenu)
            {

                Console.WriteLine($"Menu Number: #{item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Descritption: {item.MealDescription}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: ${item.Price}");

            }

        }

        private void ShowMenuItemNameandNumber()
        {
            List<MenuItem> fullMenu = _repo.GetMenu();
            foreach (MenuItem item in fullMenu)
            {

                Console.WriteLine($"Menu Number: #{item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n");
            }

        }


        private void ViewMenuItemByNumber()
        {
            Console.Clear();
            ShowMenuItemNameandNumber();

            Console.WriteLine("Enter Menu Number:");
            MenuItem item = _repo.GetMenuItemByNumber(Convert.ToInt32(Console.ReadLine()));

            if (item != null)
            {
                Console.WriteLine($"Menu Number: #{item.MealNumber}\n" +
                     $"Meal Name: {item.MealName}\n" +
                     $"Meal Descritption: {item.MealDescription}\n" +
                     $"Ingredients: {item.Ingredients}\n" +
                     $"Price: ${item.Price}");
            }
            else
            {
                Console.WriteLine("Can not find that Menu Item.");
            }

        }

        private void UpdateMenuItem()
        {
            Console.Clear();
            ShowMenuItemNameandNumber();
            Console.WriteLine("Enter the number of the Menu Item you would like to update:");
            int oldItem = Convert.ToInt32(Console.ReadLine());

            MenuItem newItem = new MenuItem();
            //number
            Console.WriteLine("Enter Menu Number:");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            //name
            Console.WriteLine("Enter Meal Name:");
            newItem.MealName = (Console.ReadLine());
            //descrip
            Console.WriteLine("Enter Meal Desription:");
            newItem.MealDescription = (Console.ReadLine());
            //ingr
            Console.WriteLine("Enter Meal Ingredients:");
            newItem.Ingredients = (Console.ReadLine());
            //price
            Console.WriteLine("Enter Meal Price:");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAddedCorrectly = _repo.UpdateMenuItemByNumber(oldItem, newItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The Meal was updated");
            }
            else
            {
                Console.WriteLine("Could not update the Meal.");
            }
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
           ShowMenuItemNameandNumber();

            Console.WriteLine("Enter Menu number of the meal you would like to delete:");
            
            int itemDelete = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _repo.DeleteMenuByNumber(itemDelete);

            if (wasDeleted)
            {
                Console.WriteLine("Menu Item was deleted");
            }
            else
            {
                Console.WriteLine("Could not delete Menu Item");
            }
        }

        private void SeedContent()
        {
            MenuItem pizzaPep = new MenuItem(1, "Pepperoni Pizza", "Fresh Slice of Pepperoni Pizza", " Pepperoni and Cheese", 3.99);
            MenuItem pizzaChe = new MenuItem(2, "Cheese Pizza", "Fresh Slice of Cheese Pizza", "Just Cheese", 2.99);


            _repo.AddMenuItem(pizzaPep);
            _repo.AddMenuItem(pizzaChe);

        }
    }
}
