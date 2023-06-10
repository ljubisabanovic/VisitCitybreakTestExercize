using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VisitCitybreakTestExercize.Pages;

namespace VisitCitybreakTestExercize
{     

    [TestFixture]
    public class ConfirmedReservation
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void ButtonClickTest()
        {
            // Call the test method and pass the driver instance
            Utilities.ItemHelper.PerformButtonClickTest(driver);

            ConfirmationPage.ValidateConfirmationMessage(driver);
            // Add test assertions or additional actions if needed
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Close();
        }
    }
}
