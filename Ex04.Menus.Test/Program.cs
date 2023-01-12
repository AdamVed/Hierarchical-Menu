namespace Project1
{
    using WithInterfaces;
    using WithDelegates;
    using B20_Ex04__Adam;
    using Project2Ex04.Menus.Delegates;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            MenuWithDelegates menu = new MenuWithDelegates();
            Menu menuTry = new Menu();

            ////With Interface
            WithInterfaces.CountCapitals capital = new WithInterfaces.CountCapitals();
            WithInterfaces.Date date = new WithInterfaces.Date();
            WithInterfaces.Time time = new WithInterfaces.Time();
            WithInterfaces.CurrVersion version = new WithInterfaces.CurrVersion();

            menuTry.CreateMenu("Versions and Digits", null, "1", null);
            menuTry.CreateMenu("Show Data/Time", null, "2", null);
            menuTry.CreateMenu("Count Capitals", "1", "3", capital as WithInterfaces.CountCapitals);
            menuTry.CreateMenu("Show Version", "1", "4", version as WithInterfaces.CurrVersion);
            menuTry.CreateMenu("Show Time", "2", "5", time as WithInterfaces.Time);
            menuTry.CreateMenu("Show Date", "2", "6", date as WithInterfaces.Date);
            menuTry.MenuNavigation();

            ////With Delegates
            WithDelegates.CountCapitals capitals = new WithDelegates.CountCapitals();
            WithDelegates.CurrVersion currVersion = new WithDelegates.CurrVersion();
            WithDelegates.Time currTime = new WithDelegates.Time();
            WithDelegates.Date currDate = new WithDelegates.Date();

            menu.MenuCreation("Versions and Digits", null, "1", null);
            menu.MenuCreation("Show Data/Time", null, "2", null);
            menu.MenuCreation("Count Capitals", "1", "3", capitals as WithDelegates.CountCapitals);
            menu.MenuCreation("Show Version", "1", "4", currVersion as WithDelegates.CurrVersion);
            menu.MenuCreation("Show Time", "2", "5", currTime as WithDelegates.Time);
            menu.MenuCreation("Show Date", "2", "6", currDate as WithDelegates.Date);
            menu.MenuNavigation();
        }
    }
}
