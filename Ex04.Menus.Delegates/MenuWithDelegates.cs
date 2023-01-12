namespace Project2Ex04.Menus.Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MenuWithDelegates
    {
        private List<MenuItem> m_OurList = new List<MenuItem>();

        public void MenuCreation(string i_Text, string i_ParentId, string i_Id, object i_ItemAction)
        {
            if (m_OurList.Count == 0)
            {
                m_OurList.Add(new MenuItem());
                m_OurList[0].ItemId = "-1";
                m_OurList[0].Text = "Exit";
            }

            if (i_ParentId == null)
            {
                MenuItem ourItem = new MenuItem();
                ourItem.ItemId = i_Id;
                ourItem.Text = i_Text;
                ourItem.ItemAction = i_ItemAction;
                m_OurList.Add(ourItem);
            }
            else
            {
                AddItem(i_Text, i_ParentId, m_OurList, i_Id, i_ItemAction);
            }
        }

        public void AddItem(string i_Text, string i_ParentId, List<MenuItem> i_ListOfItems, string i_Id, object i_ItemAction)
        {
            foreach (MenuItem option in i_ListOfItems)
            {
                if (i_ParentId == option.ItemId)
                {
                    if (option.ItemList.Count == 0)
                    {
                        MenuItem item2 = new MenuItem();
                        item2.Text = "Back";
                        item2.ItemId = "-1";
                        option.ItemList.Add(item2);
                    }

                    MenuItem item1 = new MenuItem();
                    item1.Text = i_Text;
                    item1.ItemId = i_Id;
                    item1.ItemAction = i_ItemAction;
                    EventArgs e = null;

                    item1.Clicked += Item_Clicked;

                    option.ItemList.Add(item1);
                    break;
                }
                else
                {
                    AddItem(i_Text, i_ParentId, option.ItemList, i_Id, i_ItemAction);
                }
            }
        }

        public void MenuNavigation()
        {
            int i = 1, choice = 0;
            string input;

            Console.WriteLine("Menu:");

            foreach (MenuItem something in m_OurList)
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

                    while ((m_OurList[choice].ItemList.Count != 0))
                    {
                        ShowNextLevel(m_OurList[choice].ItemList);
                        m_OurList = m_OurList[choice].ItemList;

                        Console.WriteLine("Choose an option: ");
                        input = Console.ReadLine();
                        choice = int.Parse(input);
                        CheckIfInList(choice);
                    }

                    m_OurList[choice - 1].TellIWasChosen();

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

        public void CheckIfInList(int choice)
        {
            if (m_OurList.Count <= choice)
            {
                throw new IndexOutOfRangeException(string.Format("Out of range"));
            }
        }

        public void ShowNextLevel(List<MenuItem> currLevel)
        {
            int i = 1;

            foreach (MenuItem option in currLevel)
            {
                Console.Write("{0}.{1} ", i, option.Text);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void Item_Clicked(object something, EventArgs e)
        {
            ((something as MenuItem).ItemAction as ClickEventArgs).MethodActivasion();
        }
    }
}