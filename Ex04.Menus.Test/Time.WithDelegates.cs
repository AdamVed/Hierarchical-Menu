namespace WithDelegates
{
    using Project2Ex04.Menus.Delegates;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Time : ClickEventArgs
    {
        public override void MethodActivasion()
        {
            Console.WriteLine("Current time: {0}", DateTime.Now.ToString("HH:mm:ss tt"));
        }
    }
}