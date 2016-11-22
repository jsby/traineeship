﻿using System;
using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Elements;

namespace TestCars.bin.Debug.TestCars.Pages
{
    class CarOverviewPage : CarsParentPage
    {
        private Label lblEngine = new Label(By.XPath("//td[@id='engine']"), "Label engine");
        private Label lblTransmission = new Label(By.XPath("//td[@id='transmission']"), "Label transmission");

        public CarOverviewPage()
        {
            lblEngine.IsDisplayed();
        }

        public string GetEngine()
        {
            return lblEngine.GetText();
        }

        public string GetTransmission()
        {
            return lblTransmission.GetText();
        }
    }
}
