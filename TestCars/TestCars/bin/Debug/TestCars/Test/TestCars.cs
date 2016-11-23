using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCars.bin.Debug.FrameWork.BaseTest;
using TestCars.bin.Debug.FrameWork.Utils;
using TestCars.bin.Debug.TestCars.Models;
using TestCars.bin.Debug.TestCars.Pages;

namespace TestCars.bin.Debug.TestCars.Test
{
    [TestClass]
    public class TestCars : BaseTest
    {
        [TestMethod]
        public void TestMethod()
        {
            List<Car> cars = new List<Car>();
            HomePage homePage = new HomePage();
            do
            {//2000 Ferrari 456 GT
                homePage.GetMainMenu().GetItem(ReadXML.GetData("mainMenuItem"), ReadXML.GetData("mainSubMenuItem"));
                ReviewsPage reviewsPage = new ReviewsPage();
                Car car = reviewsPage.SearchCar();
                System.Diagnostics.Trace.WriteLine(car.GetMake());
                System.Diagnostics.Trace.WriteLine(car.GetModel());
                System.Diagnostics.Trace.WriteLine(car.GetYear());
                CurrentCarReviewsPage currentCarReviewsPage = new CurrentCarReviewsPage();
                currentCarReviewsPage.GoToModelDetails();
                CarInfoPage carInfoPage = new CarInfoPage();
                if (carInfoPage.GetNumOfTrims() == 0)
                {
                    continue;
                }
                if (carInfoPage.GetNumOfTrims() == 1 & cars.Count == 1)
                {
                    continue;
                }
                carInfoPage.GetCarMenu().GetItem(ReadXML.GetData("carMenuItem"));
                carInfoPage.GetCarDetails();
                CarOverviewPage carOverviewPage = new CarOverviewPage();
                car.SetEngine(carOverviewPage.GetEngine());
                car.SetTransmission(carOverviewPage.GetTransmission());
                cars.Add(car);
            } while (cars.Count != 2);
            driver.Navigate().Back();
            CarInfoPage carToCompareInfoPage = new CarInfoPage();
            carToCompareInfoPage.GoToCompare();
        }
    }
}