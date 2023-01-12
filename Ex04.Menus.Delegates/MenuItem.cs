namespace Project2Ex04.Menus.Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public delegate void ClickEventHandler(object sender, ClickEventArgs e);

    public class ClickEventArgs : EventArgs
    {
        public virtual void MethodActivasion()
        {
        }
    }

    public class MenuItem
    {
        ////attributes
        private string m_Text;
        private string m_ItemId;
        private object m_ItemAction;
        private List<MenuItem> m_ItemList = new List<MenuItem>();

        public event EventHandler Clicked;

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

        public List<MenuItem> ItemList
        {
            get { return this.m_ItemList; }
            set { this.m_ItemList = value; }
        }

        public string ItemId
        {
            get { return this.m_ItemId; }
            set { this.m_ItemId = value; }
        }

        ////methods
        public void TellIWasChosen()
        {
            EventArgs e = this.ItemAction as ClickEventArgs;
            OnClick(e);
        }

        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = Clicked;

            handler.Invoke(this, e);
        }
    }
}