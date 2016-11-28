using Ranorex;
using Ranorex.Core;

namespace TestCalculator.Framework.Elements
{
    class TextField : BaseElement
    {
        private readonly Text _text;
        public TextField(string name, RxPath rxPath) : base(name, rxPath)
        {
            _text = Element;
        }

        public string GetText()
        {
            return _text.TextValue;
        }
    }
}
