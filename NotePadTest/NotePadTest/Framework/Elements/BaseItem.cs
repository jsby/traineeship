using log4net;
using NotePadTest.Framework.Entities;
using NotePadTest.Framework.Utils;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WPFUIItems;

namespace NotePadTest.Framework.Elements
{
    public class BaseItem<T> where T : UIItem
    {
        protected static ILog Log = Logger.GetInstance();

        protected string Name { get; set; }

        public BaseItem(T uiItem, string name)
        {
            Name = name;
            UiItem = uiItem;
        }

        public T UiItem { get; set; }

        public bool UiItemExists()
        {
            return UiItem != null;
        }

        protected static T FindUiItem(SearchCriteria searchCriteria, UIItem scope)
        {
            scope = Scope.MainWindow.Window;
            T matchingUiItem = scope.Get<T>(searchCriteria);
            return matchingUiItem;
        }

        public void Click()
        {
            Log.Info(Name + ": Click");
            UiItem.Click();
        }
    }
}
