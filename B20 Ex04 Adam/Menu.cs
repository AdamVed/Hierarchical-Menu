using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex04__Adam
{
    public class Menu
    {
        Item item = new Item();

        private List<Item> m_OurList = new List<Item>();

        public void CreateMenu(string i_Text, string i_ParentId, string i_Id, object i_ItemAction)
        {
            if (m_OurList.Count == 0)
            {
                m_OurList.Add(new Item());
                m_OurList[0].ItemID = "-1";
                m_OurList[0].Text = "Exit";
            }

            if (i_ParentId == null)
            {
                Item item1 = new Item();
                item1.ItemID = i_Id;
                item1.Text = i_Text;
                item1.ItemAction = i_ItemAction;
                m_OurList.Add(item1);
            }
            else
            {
                bool isFirst = true;
                AddItem(i_Text, i_ParentId, m_OurList, i_Id, i_ItemAction, isFirst);
            }
        }

        public void AddItem(string i_Text, string i_ParentID, List<Item> myItems, string i_Id, object i_Action, bool isFirst)
        {
            foreach (Item option in myItems)
            {
                if (i_ParentID == option.ItemID)
                {
                    Item item1 = new Item();

                    if (option.MyItems.Count == 0)
                    {
                        item1.Text = "Back";
                        item1.ItemID = "-1";
                        option.MyItems.Add(item1);
                    }

                    Item item2 = new Item();
                    item2.Text = i_Text;
                    item2.ItemID = i_Id;
                    item2.ItemAction = i_Action;
                    option.MyItems.Add(item2);
                    break;
                }
                else
                {
                    AddItem(i_Text, i_ParentID, option.MyItems, i_Id, i_Action, isFirst);
                }
            }
        }

        public void MenuNavigation()
        {
            int i = 0, choice = 0;
            string input;

            Console.WriteLine("Menu:");

            foreach (Item something in m_OurList)
            {
                Console.Write("{0}.{1} ", i, something.Text);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine();

            ////navigation
            bool isNumber = false;
            Console.WriteLine("Choose an option: ");
            input = Console.ReadLine();

            while (isNumber == false)
            {
                try
                {
                    choice = int.Parse(input);
                    isNumber = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please choose a number: ");
                    input = Console.ReadLine();
                }
            }
           
            while (choice != 0)
            {
                try
                {
                    CheckIfInList(choice);

                    while ((m_OurList[choice].MyItems.Count != 0)) 
                    {
                        Console.Clear();
                        Console.WriteLine("{0}: ", m_OurList[choice].Text);
                        Console.WriteLine();

                        ShowNextLevel(m_OurList[choice].MyItems); 
                        m_OurList = m_OurList[choice].MyItems; 

                        Console.WriteLine("Choose an option: ");
                        input = Console.ReadLine();
                        choice = int.Parse(input);
                        CheckIfInList(choice);
                        Console.Clear();
                    }

                    m_OurList[choice].TellIWasChosen(); 

                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();

                    break;
                }
                catch (IndexOutOfRangeException) 
                {
                    Console.WriteLine("Out of range!");
                    break;
                }
            }
        }

        public void CheckIfInList(int i_Choice)
        {
            if (m_OurList.Count <= (i_Choice)) //choice-1
            {
                throw new IndexOutOfRangeException(string.Format("Out of range"));
            }
        }

        public int CheckIfNumber(string i_Choice)
        {
            int conversionToInt = int.Parse(i_Choice);
            return conversionToInt;
        }

        public void ShowNextLevel(List<Item> currLevel)
        {
            int i = 0;

            foreach (Item option in currLevel)
            {
                Console.Write("{0}.{1} ", i, option.Text);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}