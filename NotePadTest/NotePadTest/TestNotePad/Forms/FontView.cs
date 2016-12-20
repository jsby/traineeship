using NotePadTest.Framework.Elements;
using TestStack.White.UIItems.Finders;

namespace NotePadTest.TestNotePad.Forms
{
    public class FontView
    {
        public static MButton ButtonOk
        {
            get
            {
                return MButton.Get(SearchCriteria.ByAutomationId("1"), "Font OK");

            }
        }

        public static MButton ButtonCancel
        {
            get
            {
                return MButton.Get(SearchCriteria.ByAutomationId("2"), "Font Cancel");

            }
        }

        public static MTextBox TextBoxFontType
        {
            get
            {
                return MTextBox.Get(SearchCriteria.ByAutomationId("1001"), "TextBox Font type");
            }
        }

        public static MTextBox TextBoxFontSize
        {
            get
            {
                return MTextBox.Get(SearchCriteria.ByAutomationId("1001"), "TextBox Font size");
            }
        }

        public static MComboBox ComboBoxFontType
        {
            get
            {
                return MComboBox.Get(SearchCriteria.ByAutomationId("1136"), "Font type");
            }
        }

        public static MComboBox ComboBoxFontSize
        {
            get
            {
                return MComboBox.Get(SearchCriteria.ByAutomationId("1138"), "Font size");
            }
        }

        public static MComboBox ComboBoxScript
        {
            get
            {
                return MComboBox.Get(SearchCriteria.ByAutomationId("1140"), "Script");
            }
        }
    }
}
