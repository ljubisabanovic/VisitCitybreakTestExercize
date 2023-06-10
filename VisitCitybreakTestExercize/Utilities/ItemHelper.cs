using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using VisitCitybreakTestExercize.Pages;

namespace VisitCitybreakTestExercize.Utilities
{
    public class ItemHelper
    {
        public static void PerformButtonClickTest(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

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

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("form#PaymentDetailsForm button[name='CommitReservation']")));
            IJavaScriptExecutor ConfirmAndPay = (IJavaScriptExecutor)driver;
            ConfirmAndPay.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector("form#PaymentDetailsForm button[name='CommitReservation']")));
        }
    }
}