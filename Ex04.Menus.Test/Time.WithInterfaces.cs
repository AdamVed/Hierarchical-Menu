namespace WithInterfaces
{
    using B20_Ex04__Adam;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Time : IClickable
    {
        public void ItemAction()
        {
            Console.WriteLine("Current time: {0}", DateTime.Now.ToString("HH:mm:ss tt"));
        }
    }
}