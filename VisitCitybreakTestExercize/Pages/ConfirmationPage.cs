using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitCitybreakTestExercize.Pages
{
    public static class ConfirmationPage
    {
        public static void ValidateConfirmationMessage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            By confirmationMessageLocator = By.XPath("/html//div[@id='Citybreak_container']/div[@class='Citybreak_inner cb-framework']/div[@class='cb-framework cb-fw-checkout']//h1[.='Thank you! Your reservation is confirmed.']");
            IWebElement confirmationMessageElement = wait.Until(ExpectedConditions.ElementIsVisible(confirmationMessageLocator));
                        
            Assert.IsTrue(confirmationMessageElement.Displayed, "Confirmation message is not displayed.");
        }
    }
}
