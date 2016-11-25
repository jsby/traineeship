using System.Collections.Generic;
using KasperskyTest.FrameWork;
using KasperskyTest.FrameWork.Utils;
using KasperskyTest.TestKPC.Models;
using KasperskyTest.TestKPC.Pages;
using KasperskyTest.TestKPC.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KasperskyTest.TestKPC.Test
{
    [TestClass]
    public class TestKpc : BaseTest
    {
        [TestInitialize]
        public void TestKpcInitialize()
        {
            ExcelReader.LoadFile(XmlReader.GetData("excelPath"));
        }

        [TestMethod]
        public void TestMethod()
        {
            Log.Info("STEP 1");
            HomePage homePage = new HomePage();
            homePage.LogIn(ExcelReader.GetValue("username"), ExcelReader.GetValue("password"));
            DevicesPage devicesPage = new DevicesPage();

            Log.Info("STEP 2");
            devicesPage.GetMainMenu().GetItem(XmlReader.GetData("mainMenuItem"));
            StorePage storePage = new StorePage();

            Log.Info("STEP 3");
            List<Product> productsFromSite = new List<Product>();
            foreach (var product in ExcelReader.GetValues("product"))
            {
                storePage.GetStoreMenu().GetSubItem(XmlReader.GetData("storeMenuItem"), product);
                ProductPage productPage = new ProductPage();
                productsFromSite.Add(productPage.GetProduct());
            }
            Log.Info("products from site are ready to compare");

            Log.Info("STEP 4");
            List<Product> productsFromExcel = new List<Product>();
            foreach (var product in productsFromSite)
            {
                List<string> devices = ExcelReader.GetValuesWhere("devices", "product", product.Name);
                List<string> years = ExcelReader.GetValuesWhere("year", "product", product.Name);
                List<string> costs = ExcelReader.GetValuesWhere("cost", "product", product.Name);
                List<Option> options = new List<Option>();
                for (int optionsNum = 0; optionsNum < devices.Count; optionsNum++)
                {
                    options.Add(new Option(devices[optionsNum], years[optionsNum], costs[optionsNum]));
                }
                productsFromExcel.Add(new Product(product.Name, options));
            }
            Log.Info("products from excel are ready to compare");

            Log.Info("STEP 5");
            CollectionAssert.AreEqual(productsFromExcel, productsFromSite, new ProductComparer(), "collections are not equal");
        }
    }
}