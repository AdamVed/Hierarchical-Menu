namespace WithDelegates
{
    using Project2Ex04.Menus.Delegates;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Date : ClickEventArgs
    {
        public override void MethodActivasion()
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("dd-MM-yyyy"));
        }
    }
}