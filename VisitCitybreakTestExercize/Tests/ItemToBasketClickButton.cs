using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using VisitCitybreakTestExercize.Pages;
using Docker.DotNet.Models;
using NUnit.Framework.Internal;
using System.Runtime.Remoting.Lifetime;
using System.Xml.Linq;

namespace VisitCitybreakTestExercize
{
    public static class ItemToButtonClickTest
    {
        public static void PerformButtonClickTest(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));

            TestPage tsPage = new TestPage(driver);
            tsPage.NavigateToOnline3TestCitybreak();


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-of-type(3) > .cb-quantity > div[role='spinbutton'] > .cb-btn.cb-plus")));
            IWebElement buttonElement = driver.FindElement(By.CssSelector("div:nth-of-type(3) > .cb-quantity > div[role='spinbutton'] > .cb-btn.cb-plus"));
            buttonElement.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cb-action > a:nth-of-type(1)")));
            IJavaScriptExecutor ContinueToDate = (IJavaScriptExecutor)driver;
            ContinueToDate.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".cb-action > a:nth-of-type(1)")));

            IWebElement buttonTime = driver.FindElement(By.CssSelector(".cb-list-option.cb-spacer-top-xl > div > div:nth-of-type(2) span"));
            buttonTime.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cb-mfp-content.cb-wrapper-click-trigger .cb-action > a:nth-of-type(1)")));
            IJavaScriptExecutor ContinueToCart = (IJavaScriptExecutor)driver;
            ContinueToCart.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".cb-mfp-content.cb-wrapper-click-trigger .cb-action > a:nth-of-type(1)")));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cb-footer > div > div > .cb-action > a:nth-of-type(2)")));
            IJavaScriptExecutor AdToCart = (IJavaScriptExecutor)driver;
            AdToCart.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".cb-footer > div > div > .cb-action > a:nth-of-type(2)")));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cb-action > div:nth-of-type(2) > .cb-btn.cb-btn-custom.cb-btn-lg.cb-btn-primary")));
            IJavaScriptExecutor ContinueToForm = (IJavaScriptExecutor)driver;
            ContinueToForm.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".cb-action > div:nth-of-type(2) > .cb-btn.cb-btn-custom.cb-btn-lg.cb-btn-primary")));

            IWebElement dropDownCountry = driver.FindElement(By.Id("travellerCountry"));
            SelectElement country = new SelectElement(dropDownCountry);
            country.SelectByValue("SE");

            Actions.FillPaymentForm(driver, PaymentPage.Credentials.FirstName, PaymentPage.Credentials.LastName, PaymentPage.Credentials.Email, PaymentPage.Credentials.Address1, PaymentPage.Credentials.City, PaymentPage.Credentials.PostalCode, PaymentPage.Credentials.EmailConfirm, PaymentPage.Credentials.MobileNo);
                        
            //IWebElement checkboxElement = driver.FindElement(By.Id("termsConfirmation"));
            //checkboxElement.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("form#PaymentDetailsForm button[name='CommitReservation']")));
            IJavaScriptExecutor ConfirmAndPay = (IJavaScriptExecutor)driver;
            ConfirmAndPay.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector("form#PaymentDetailsForm button[name='CommitReservation']")));

            WebDriverWait waitConfirmationMessage = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitConfirmationMessage.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html//div[@id='Citybreak_container']/div[@class='Citybreak_inner cb-framework']/div[@class='cb-framework cb-fw-checkout']//h1[.='Thank you! Your reservation is confirmed.']")));

            IWebElement confirmationMessageElement = driver.FindElement(By.XPath("/html//div[@id='Citybreak_container']/div[@class='Citybreak_inner cb-framework']/div[@class='cb-framework cb-fw-checkout']//h1[.='Thank you! Your reservation is confirmed.']"));
            Assert.IsTrue(confirmationMessageElement.Displayed, "Confirmation message is not displayed.");

        }
    }
    [TestFixture]
    public class TestClass
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
            ItemToButtonClickTest.PerformButtonClickTest(driver);

            // Add test assertions or additional actions if needed
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(TimeSpan.FromSeconds(15));
            driver.Close();
        }
    }
}
