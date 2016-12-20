using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace NotePadTest.Framework.Elements
{
    public class MTextBox : BaseItem<TextBox>
    {
        public MTextBox(TextBox uiItem, string name) : base(uiItem, name)
        {
        }

        public static MTextBox Get(SearchCriteria searchCriteria, string name, UIItem scope = null)
        {
            var textBox = FindUiItem(searchCriteria, scope);
            return new MTextBox(textBox, name);
        }

        public string Text
        {
            get
            {
                return UiItem.Text;
            }
        }

        public void EnterText(string text)
        {
            UiItem.Enter(text);
        }
    }
}
