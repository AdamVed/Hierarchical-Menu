namespace WithDelegates
{
    using Project2Ex04.Menus.Delegates;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CurrVersion : ClickEventArgs
    {
        public override void MethodActivasion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }
    }
}