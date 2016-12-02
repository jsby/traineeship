using log4net;
using TestCalc.Framework.Utils;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestCalc.Framework.Elements
{
    public class BaseElement
    {
        protected static ILog Log = Logger.GetInstance();
        protected IUIItem UiItem;
        protected string Name;
        protected SearchCriteria SearchCriteria;

        public BaseElement(Window window, string name, SearchCriteria searchCriteria)
        {
            Name = name;
            SearchCriteria = searchCriteria;
            UiItem = window.Get(searchCriteria);
        }

        public string GetName()
        {
            return Name;
        }
    }
}
