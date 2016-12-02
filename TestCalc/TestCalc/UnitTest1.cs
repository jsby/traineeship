using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using TestCalc.Framework.Utils;
using TestCalc.TestCalc.Apps;
using TestStack.White;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;
using Button = TestStack.White.UIItems.Button;

namespace TestCalc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Application.Launch(XmlReader.GetData("appPath")).Process.WaitForExit();
            //Application calc = Application.AttachOrLaunch(new ProcessStartInfo(XmlReader.GetData("appPath")));
            Application calc = new NullApplication();
            // Application calc = Application.Attach("calc");
            //Application notepad = Application.Launch("notepad");
            //Thread.Sleep(3000);
            //List<Window> windows = new List<Window>();
            //windows = TestStack.White.Desktop.Instance.Windows();
            // List<Window> windows = calc.GetWindows();
            /*Report.Log(ReportLevel.Info, "******* " + windows.Count);
            foreach (var w in windows)
            {
                Report.Log(ReportLevel.Info, "window: " + w.Title + " / " + w.Visible + " / " + w.Name);
            }*/
            //Process[] processes = Process.GetProcesses();
            //Report.Log(ReportLevel.Info, "******* " + processes.Length);
            foreach (var proc in Process.GetProcesses())
            {
                //Report.Log(ReportLevel.Info, "process: " + proc.ProcessName + " / " + proc.MainWindowTitle);
                if (proc.MainWindowTitle.Equals("Calculator"))
                {
                    //Report.Log(ReportLevel.Info, "!!!!!!!!!!!!!! process: " + proc.ProcessName + " / " + proc.MainWindowTitle);
                    calc = Application.Attach(proc.ProcessName);
                }
            }
            Window window = calc.GetWindow("Calculator");
            //var window = calc.GetWindows().FirstOrDefault();
            var txt = window.GetElement(SearchCriteria.ByAutomationId("CalculatorResults"));
            var btn = window.GetElement(SearchCriteria.ByAutomationId("num1Button"));
            var btn1 = window.Get<Button>(SearchCriteria.ByAutomationId("num1Button"));

            //Label lbl = txt;
            //Report.Log(ReportLevel.Info, txt.Current.AutomationId);
            /* TestStack.White.UIItems.Button btnNum1 = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("num1Button"));
             TestStack.White.UIItems.Button btnNum2 = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("num2Button"));
             TestStack.White.UIItems.Button btnPlus = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("plusButton"));
             TestStack.White.UIItems.Button btnEqual = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("equalButton"));
             btnNum1.Click();
             btnPlus.Click();
             btnNum2.Click();
             btnEqual.Click();*/
            //window.Close();
        }
    }
}
