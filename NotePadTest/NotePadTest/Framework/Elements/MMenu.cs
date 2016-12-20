using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;

namespace NotePadTest.Framework.Elements
{
    public class MMenu : BaseItem<Menu>
    {
        public MMenu(Menu menu, string name) : base(menu, name)
        {
        }

        public static MMenu Get(SearchCriteria searchCriteria, string name, UIItem scope = null)
        {
            var menu = FindUiItem(searchCriteria, scope);
            return new MMenu(menu, name);
        }
    }
}
