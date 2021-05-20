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
            Console.WriteLine(@"
     '||\   /||`                             
      ||\\.//||                              
      ||     ||  .|''|, `||''|,  '||  ||`    
      ||     ||  ||..||  ||  ||   ||  ||     
     .||     ||. `|...  .||  ||.  `|..'|.    
                                             
                                             
  '||\   /||`         '||                    
   ||\\.//||           ||                    
   ||     ||   '''|.   || //`  .|''|, '||''| 
   ||     ||  .|''||   ||<<    ||..||  ||    
  .||     ||. `|..||. .|| \\.  `|...  .||.   
                                             
                                             
        ,'''|, .''', .''', .''',             
            || |   | |   | |   |             
         '''|| |   | |   | |   |             
            || |   | |   | |   |             
        '...|' `,,,' `,,,' `,,,'           ");

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\n\tPress any Key to Continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n\tPlease select an option: \n" +
                    "\n\t1. Add Menu Item\n" +
                    "\t2. Show Full Menu\n" +
                    "\t3. Veiw Menu Item by Number\n" +
                    "\t4. Update Menu Item\n" +
                    "\t5. Delete Menu Item\n" +
                    "\t6. Exit");
                Console.Write("\n\t Enter Number # ");
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
                        Console.WriteLine("\tPlease enter a valid number");
                        break;

                }
            }
        }

        private void AddMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();
            //number
            Console.Write("\n\tEnter Menu Number: # ");
            string check = InputCheck();
            newItem.MealNumber = Convert.ToInt32(check);
            //name
            Console.Write("\n\tEnter Meal Name: ");
            newItem.MealName = (Console.ReadLine());
            //descrip
            Console.Write("\n\tEnter Meal Desription: \n" +
                "\n\t");
            newItem.MealDescription = (Console.ReadLine());
            //ingr
            Console.Write("\n\tEnter Meal Ingredients:\n" +
                "\n\t");
            newItem.Ingredients = (Console.ReadLine());
            //price
            Console.Write("\n\tEnter Meal Price: $ ");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAddedCorrectly = _repo.AddMenuItem(newItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("\n\tThe Meal was added");
            }
            else
            {
                Console.WriteLine("\n\tCould not add the Meal.");
            }
            //Console.ReadKey();

        }

        private void ShowFullMenu()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetMenu();
            foreach (MenuItem item in fullMenu)
            {

                Console.WriteLine($"\n\tMenu Number: #{item.MealNumber}\n" +
                    $"\tMeal Name: {item.MealName}\n" +
                    $"\tMeal Descritption: {item.MealDescription}\n" +
                    $"\tIngredients: {item.Ingredients}\n" +
                    $"\tPrice: ${item.Price}\n" +
                    $"\n.........................................................................\n");

            }
            //Console.ReadKey();


        }

        private void ShowMenuItemNameandNumber()
        {
            List<MenuItem> fullMenu = _repo.GetMenu();
            foreach (MenuItem item in fullMenu)
            {

                Console.WriteLine($"\tMenu Number: #{item.MealNumber}\n" +
                    $"\tMeal Name: {item.MealName}\n" +
                    $"\n.........................................................................\n");
            }

        }


        private void ViewMenuItemByNumber()
        {
            bool findItem = true;
            while (findItem)
            {
                Console.Clear();
                ShowMenuItemNameandNumber();

                Console.Write("\n\tEnter Menu Number: # ");
                string input = Console.ReadLine();
               
                if (input != "")
                {
                    MenuItem item = _repo.GetMenuItemByNumber(Convert.ToInt32(input));


                    if (item != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"\n\tMenu Number: #{item.MealNumber}\n" +
                             $"\tMeal Name: {item.MealName}\n" +
                             $"\tMeal Descritption: {item.MealDescription}\n" +
                             $"\tIngredients: {item.Ingredients}\n" +
                             $"\tPrice: ${item.Price}\n" +
                            $"\n.......................................................................\n");
                        findItem = false;

                    }
                    else
                    {
                        Console.WriteLine("\n\tCan not find that Menu Item.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tCan not find that Menu Item.");
                    Console.ReadKey();
                }
            }
        }

        private void UpdateMenuItem()
        {
            Console.Clear();
            ShowMenuItemNameandNumber();
            Console.Write("\n\tEnter the number of the Menu Item you would like to update:\n" +
                "\n\t # ");
            int oldItem = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            MenuItem newItem = new MenuItem();
            //number
            Console.Write("\n\tEnter Menu Number: # ");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            //name
            Console.Write("\n\tEnter Meal Name: ");
            newItem.MealName = (Console.ReadLine());
            //descrip
            Console.Write("\n\tEnter Meal Desription:\n" +
                "\n\t");
            newItem.MealDescription = (Console.ReadLine());
            //ingr
            Console.Write("\n\tEnter Meal Ingredients:\n" +
                "\n\t");
            newItem.Ingredients = (Console.ReadLine());
            //price
            Console.Write("\tEnter Meal Price: $ ");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAddedCorrectly = _repo.UpdateMenuItemByNumber(oldItem, newItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("\n\tThe Meal was updated");
            }
            else
            {
                Console.WriteLine("\n\tCould not update the Meal.");
            }
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            ShowMenuItemNameandNumber();

            Console.Write("\n\tEnter Menu number of the meal you would like to delete:\n" +
                "\n\t # ");

            int itemDelete = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _repo.DeleteMenuByNumber(itemDelete);

            if (wasDeleted)
            {
                Console.WriteLine("\n\tMenu Item was deleted");
            }
            else
            {
                Console.WriteLine("\n\tCould not delete Menu Item");
            }
        }

        private void SeedContent()
        {
            MenuItem pizzaPep = new MenuItem(1, "Pepperoni Pizza", "Fresh Slice of Pepperoni Pizza", " Pepperoni and Cheese", 3.99);
            MenuItem pizzaChe = new MenuItem(2, "Cheese Pizza", "Fresh Slice of Cheese Pizza", "Just Cheese", 2.99);


            _repo.AddMenuItem(pizzaPep);
            _repo.AddMenuItem(pizzaChe);

        }

        private string InputCheck()
        {
            string input = Console.ReadLine();
            if(input != "")
            {
                return input;
            }
            else if(input != null)
            {
                return input;
            }
            else
            {
                return null;
            }
        }

    }
}
