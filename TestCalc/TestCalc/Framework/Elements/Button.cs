using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestCalc.Framework.Elements
{
    public class Button : BaseElement
    {
        private readonly TestStack.White.UIItems.Button _button;

        public Button(Window window, string name, SearchCriteria searchCriteria) : base(window, name, searchCriteria)
        {
            _button = UiItem as TestStack.White.UIItems.Button;
        }
        public void Click()
        {
            _button.Click();
            Log.Info(Name + ": click");
        }
    }
}
