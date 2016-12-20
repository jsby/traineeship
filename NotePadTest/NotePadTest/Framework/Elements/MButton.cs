using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace NotePadTest.Framework.Elements
{
    public class MButton : BaseItem<Button>
    {
        public MButton(Button button, string name) : base(button, name)
        {
        }

        public static MButton Get(SearchCriteria searchCriteria, string name, UIItem scope = null)
        {
            var button = FindUiItem(searchCriteria, scope);
            return new MButton(button, name);
        }
    }
}
