using System;
using System.Collections.Generic;
using TrainingMenu.MenuItems;

namespace TrainingMenu
{
    class Menu
    {
        public enum MenuItemCodes
        {
            Exit,
            PrintHelloWorld,
            FormulaCalculation,
            AckermannFunctionCalculation,
            StringsProcessing
        };

        public static List<MenuTaskCore> MenuItemsList = new List<MenuTaskCore>();

        private static void ClearItems()
        {
            MenuItemsList.Clear();
        }

        private static void AddItem(MenuTaskCore menuItem)
        {
            MenuItemsList.Add(menuItem);
        }

        public static void Execute()
        {
            ClearItems();
            AddItem(new MenuTaskExit());
            AddItem(new MenuTaskHelloWorld());
            AddItem(new MenuTaskCalculate());
            AddItem(new MenuTaskAckermannFunction());
            AddItem(new MenuTaskStringsProcessing());

            ShowMenu();

            int iMenuItemCode = ReadMenuItem();
            MenuItemsList[iMenuItemCode].Execute();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n-------------MENU--------------");

            int iMenuItem = 0;
            foreach (MenuTaskCore MenuItem in MenuItemsList)
            {
                Console.WriteLine($"[{iMenuItem}]: {MenuItem.Title}");
                iMenuItem++;
            }
        }

        public static int ReadMenuItem()
        {
            int iUserChoice;

            while (true)
            {
                iUserChoice = IOUtils.SafeReadInteger("Please, choose menu item and enter its code: ");
                if (!Enum.IsDefined(typeof(MenuItemCodes), iUserChoice))
                {
                    Console.WriteLine("Item with such code did not found\nRepeat the input");
                }
                else
                {
                    return iUserChoice;
                }
            }
        }
    }
}
