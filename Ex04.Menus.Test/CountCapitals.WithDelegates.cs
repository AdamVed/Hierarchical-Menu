using Project2Ex04.Menus.Delegates;
using System;
namespace WithDelegates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountCapitals : ClickEventArgs
    {
        public override void MethodActivasion()
        {
            string sentence;
            int countCapitals = 0;

            Console.WriteLine("Please enter a sentence: ");
            sentence = Console.ReadLine();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (char.IsUpper(sentence[i]) == true)
                {
                    countCapitals++;
                }
            }

            Console.WriteLine("The sentence contains {0} capital letters", countCapitals);
        }
    }
}