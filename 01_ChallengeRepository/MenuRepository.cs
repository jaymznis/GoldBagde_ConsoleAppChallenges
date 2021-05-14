using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeRepository
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();

        public bool AddMenuItem(MenuItem newItem)
        {
            int existingItems = _menuItems.Count;

           _menuItems.Add(newItem);
            bool wasAdded = (_menuItems.Count > existingItems) ? true : false;
            return wasAdded;
        }
        public List<MenuItem> GetMenu()
        {
            return _menuItems;
        }

        public MenuItem GetMenuItemByNumber(int menuNumber)
        {
            foreach (MenuItem item in _menuItems)
            {
                if(item.MealNumber == menuNumber && item.GetType() == typeof(MenuItem))
                {
                    return (MenuItem)item;
                }
            }
            return null;
        }
        public bool UpdateMenuItemByNumber(int menuNum, MenuItem newMenuItem)
        {
            MenuItem oldMenuItem = GetMenuItemByNumber(menuNum);
            {
                if(oldMenuItem != null)
                {
                    oldMenuItem.MealNumber = newMenuItem.MealNumber;
                    oldMenuItem.MealName = newMenuItem.MealName;
                    oldMenuItem.MealDescription = newMenuItem.MealDescription;
                    oldMenuItem.Ingredients = newMenuItem.Ingredients;
                    oldMenuItem.Price = newMenuItem.Price;

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteMenuByNumber(int menuNum)
        {
            MenuItem itemToDelete = GetMenuItemByNumber(menuNum);
            if(itemToDelete == null)
            {
                return false;
            }
            else
            {
                _menuItems.Remove(itemToDelete);
                return true;
            }
        }
    }
}
