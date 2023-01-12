namespace WithInterfaces
{
    using B20_Ex04__Adam;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Date : IClickable
    {
        public void ItemAction()
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("dd-MM-yyyy"));
        }
    }
}