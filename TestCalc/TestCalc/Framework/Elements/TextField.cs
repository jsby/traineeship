using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestCalc.Framework.Elements
{
    public class TextField : BaseElement
    {
        private readonly Label _text;

        public TextField(Window window, string name, SearchCriteria searchCriteria) : base(window, name, searchCriteria)
        {
            _text = UiItem as Label;
        }

        public string GetText()
        {
            return _text.Text;
        }
    }
}
