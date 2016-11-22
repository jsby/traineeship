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
            do
            {//2000 Ferrari 456 GT
                HomePage homePage = new HomePage();
                homePage.GetMainMenu().GetItem(ReadXML.GetData("mainMenuItem"), ReadXML.GetData("mainSubMenuItem"));
                ReviewsPage reviewsPage = new ReviewsPage();
                Car car = reviewsPage.SearchCar();
                CurrentCarReviewsPage currentCarReviewsPage = new CurrentCarReviewsPage();
                currentCarReviewsPage.GoToModelDetails();
                CarInfoPage carInfoPage = new CarInfoPage();
                carInfoPage.GetCarMenu().GetItem(ReadXML.GetData("carMenuItem"));
                if (!carInfoPage.AbleToViewDetails())
                {
                    continue;
                }
                if (!carInfoPage.AbleToCompare() & cars.Count == 1)
                {
                    continue;
                }
                carInfoPage.GetCarDetails();
                CarOverviewPage carOverviewPage = new CarOverviewPage();
                car.SetEngine(carOverviewPage.GetEngine());
                car.SetTransmission(carOverviewPage.GetTransmission());
                cars.Add(car);
            } while (cars.Count != 2);
        }
    }
}