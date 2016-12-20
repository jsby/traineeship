using NotePadTest.Framework.Elements;
using TestStack.White.UIItems.Finders;

namespace NotePadTest.TestNotePad.Forms
{
    public class MainView
    {
        public static MMenu MenuEdit
        {
            get
            {
                return MMenu.Get(SearchCriteria.ByAutomationId("Item 2"), "Edit");
            }
        }

        public static MMenu MenuFormat
        {
            get
            {
                return MMenu.Get(SearchCriteria.ByAutomationId("Item 3"), "Format");
            }
        }

        public static MTextBox Document
        {
            get
            {
                return MTextBox.Get(SearchCriteria.ByAutomationId("15"), "Main Document");
            }
        }

        public static MWindow WindowFont
        {
            get
            {
                return MWindow.GetModalWindow("Font");
            }
        }
    }
}
