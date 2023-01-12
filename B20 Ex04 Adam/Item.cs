namespace B20_Ex04__Adam_323656447_Inna_321907073
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IClickable
    {
        void ItemAction();
    }

    public class Item
    {
        ////attributes
        private string m_Text;
        private string m_ItemId;
        private object m_ItemAction;
        private List<Item> m_MyItems = new List<Item>();

        ////properties
        public object ItemAction
        {
            get { return this.m_ItemAction; }
            set { this.m_ItemAction = value; }
        }

        public string Text
        {
            get { return this.m_Text; }
            set { this.m_Text = value; }
        }

        public List<Item> MyItems
        {
            get { return this.m_MyItems; }
            set { this.m_MyItems = value; }
        }

        public string ItemID
        {
            get { return this.m_ItemId; }
            set { this.m_ItemId = value; }
        }

        ////methods
        public void TellIWasChosen()
        {
            notifyIWasChosen();
        }

        private void notifyIWasChosen()
        {
            if (this.ItemAction != null)
            {
                (this.ItemAction as IClickable).ItemAction();
            }
        }
    }
}