using Ranorex.Core;

namespace TestCalculator.Framework.Elements
{
    public class Button : BaseElement
    {
        private readonly Ranorex.Button _button;

        public Button(string name, RxPath rxPath) : base(name, rxPath)
        {
            _button = Element;
        }

        public void Click()
        {
            _button.Click();
        }
    }
}
