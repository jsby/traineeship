using NotePadTest.Framework.Entities;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace NotePadTest.Framework.Elements
{
    public class MWindow
    {
        public MWindow(Window window)
        {
            Window = window;
        }

        public Window Window { get; set; }

        public string Title
        {
            get
            {
                return Window.Title;
            }
        }

        public static MWindow GetWindow(SearchCriteria searchCriteria, Application scope = null)
        {
            var window = FindWindow(searchCriteria, scope);
            return new MWindow(window);
        }

        public static MWindow GetModalWindow(SearchCriteria searchCriteria, Window scope = null)
        {
            var window = FindModalWindow(searchCriteria, scope);
            return new MWindow(window);
        }

        public static MWindow GetModalWindow(string title, Window scope = null)
        {
            var window = FindModalWindow(title, scope);
            return new MWindow(window);
        }

        private static Window FindWindow(SearchCriteria searchCriteria, Application scope = null)
        {
            scope = Scope.Application.Application;
            Window matchingWindow = scope.GetWindow(searchCriteria, InitializeOption.NoCache);
            return matchingWindow;
        }

        private static Window FindModalWindow(SearchCriteria searchCriteria, Window scope = null)
        {
            scope = Scope.MainWindow.Window;
            Window matchingWindow = scope.ModalWindow(searchCriteria);
            matchingWindow.WaitWhileBusy();
            return matchingWindow;
        }

        private static Window FindModalWindow(string title, Window scope = null)
        {
            scope = Scope.MainWindow.Window;
            Window matchingWindow = scope.ModalWindow(title, InitializeOption.NoCache);
            matchingWindow.WaitWhileBusy();
            return matchingWindow;
        }

        public static void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            Scope.MainWindow.Window.Keyboard.PressSpecialKey(key);
        }
    }
}
