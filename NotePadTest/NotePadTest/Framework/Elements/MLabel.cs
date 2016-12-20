using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace NotePadTest.Framework.Elements
{
    public class MLabel : BaseItem<Label>
    {
        public MLabel(Label label, string name) : base(label, name)
        {
        }

        public static MLabel Get(SearchCriteria searchCriteria, string name, UIItem scope = null)
        {
            var label = FindUiItem(searchCriteria, scope);
            return new MLabel(label, name);
        }

        public string Text
        {
            get
            {
                return UiItem.Text;
            }
        }
    }
}
