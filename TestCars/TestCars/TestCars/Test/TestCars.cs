using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCars.FrameWork.BaseTest;
using TestCars.FrameWork.Utils;
using TestCars.TestCars.Models;
using TestCars.TestCars.Pages;

namespace TestCars.TestCars.Test
{
    [TestClass]
    public class TestCars : BaseTest
    {
        [TestMethod]
        public void TestMethod()
        {
            List<Car> cars = new List<Car>();
            log.Info("STEP 1");
            log.Info(driver.Url + "is opened");
            log.Info("STEP 2");
            HomePage homePage = new HomePage();
            do
            {
                homePage.GetMainMenu().GetItem(ReadXML.GetData("mainMenuItem"), ReadXML.GetData("mainSubMenuItem"));
                ReviewsPage reviewsPage = new ReviewsPage();
                log.Info("STEP 3 for " + (cars.Count + 1) + " car");
                Car car = reviewsPage.SearchCar();
                CurrentCarReviewsPage currentCarReviewsPage = new CurrentCarReviewsPage();
                currentCarReviewsPage.GoToModelDetails();
                CarInfoPage carInfoPage = new CarInfoPage();
                if (carInfoPage.GetNumOfTrims() == 0)
                {
                    log.Info("This car haven't trims");
                    log.Info("Go to find another one");
                    continue;
                }
                if (carInfoPage.GetNumOfTrims() == 1 & cars.Count == 1)
                {
                    log.Info("This car haven't enough trims to compare");
                    log.Info("Go to find another one");
                    continue;
                }
                log.Info("STEP 4 for " + (cars.Count + 1) + " car");
                carInfoPage.GetCarMenu().GetItem(ReadXML.GetData("carMenuItem"));
                carInfoPage.GetCarDetails();
                CarOverviewPage carOverviewPage = new CarOverviewPage();
                log.Info("STEP 5 for " + (cars.Count + 1) + " car");
                car.SetEngine(carOverviewPage.GetEngine());
                car.SetTransmission(carOverviewPage.GetTransmission());
                cars.Add(car);
                log.Info("A suitable car is found");
            } while (cars.Count != 2);
            log.Info("Cars to compare are found");
            log.Info("STEP 6");
            driver.Navigate().Back();
            CarInfoPage carToCompareInfoPage = new CarInfoPage();
            log.Info("STEP 7");
            carToCompareInfoPage.GoToCompare();
            ComparePage comparePage = new ComparePage();
            comparePage.AddCar(cars[0]);
            log.Info("STEP 8");
            Assert.IsTrue(comparePage.GetFirstEngine().Contains(cars[1].GetEngine()) & comparePage.GetSecondEngine().Contains(cars[0].GetEngine()));
        }
    }
}