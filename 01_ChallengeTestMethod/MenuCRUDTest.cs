using _01_ChallengeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_ChallengeTestMethod
{
    [TestClass]
    public class MenuCRUDTest
    {
        [TestMethod]
        public void AddItemShouldWork()
        {
            MenuItem item = new MenuItem();
            MenuRepository menu = new MenuRepository();

            bool addItem = menu.AddMenuItem(item);

            Assert.IsTrue(addItem);
        }
        public void GetMenuShouldWork()
        {
            MenuItem item = new MenuItem();
            MenuRepository menu = new MenuRepository();
            menu.AddMenuItem(item);

            List<MenuItem> showMenu = menu.GetMenu();

            bool menuMade = showMenu.Contains(item);
            Assert.IsTrue(menuMade);
        }
        private MenuItem _item;
        private MenuRepository _menu;

        [TestInitialize]

        public void Seed()
        {
            _menu = new MenuRepository();
            _item = new MenuItem(1, "Pepperoni Pizza", "Fresh Slice of Pepperoni Pizza", " Pepperoni and Cheese", 3.99);
            _menu.AddMenuItem(_item);
        }
        [TestMethod]
        public void UpdateMenuShouldWork()
        {
            _menu.UpdateMenuItemByNumber(1, new MenuItem(1, "Cheese Pizza", "Fresh Slice of Cheese Pizza", "Just Cheese", 2.99));

            Assert.AreEqual(_item.MealName, "Cheese Pizza");
        }
        
        public void DeleteMenuItemShouldWork()
        {
            bool wasDeleted = _menu.DeleteMenuByNumber(1);

            Assert.IsTrue(wasDeleted);
        }
    }
}
