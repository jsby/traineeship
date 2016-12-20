using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace NotePadTest.Framework.Elements
{
    public class MComboBox : BaseItem<ComboBox>
    {
        public MComboBox(ComboBox uiItem, string name) : base(uiItem, name)
        {
        }

        public static MComboBox Get(SearchCriteria searchCriteria, string name, UIItem scope = null)
        {
            var comboBox = FindUiItem(searchCriteria, scope);
            return new MComboBox(comboBox, name);
        }

        public void Select(string itemText)
        {
            UiItem.Select(itemText);
            Log.Info(UiItem.SelectedItemText + ": Select");
            UiItem.Click();
        }

        public void EnterText(string itemText)
        {
            UiItem.Enter(itemText);
        }

        public string SelectedItemText
        {
            get
            {
                return UiItem.SelectedItemText;

            }
        }
    }
}
