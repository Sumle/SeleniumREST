using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace SeleniumREST
{
    [TestClass]
    public class UnitTest1
    {
        //Lavede på "Cars"
        private static readonly string DriverDirectory = "C://Webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/silke/OneDrive/Skrivebord/3_semester/Programmering/JavaScript/REST/CarsAPI/index.html");

            string title = _driver.Title;
            Assert.AreEqual("Car Shop", title);

            IWebElement button = _driver.FindElement(By.Id("getAllButton"));
            button.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement carList = wait.Until(d => d.FindElement(By.Id("carList")));
            Assert.IsTrue(carList.Text.Contains("Volvo"));

            ReadOnlyCollection<IWebElement> listElement = _driver.FindElements(By.TagName("li"));
            Assert.AreEqual(3, listElement.Count);

            Assert.IsTrue(listElement[0].Text.Contains("Volvo"));
        }
    }
}