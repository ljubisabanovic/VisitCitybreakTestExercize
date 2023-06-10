using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;


namespace VisitCitybreakTestExercize
{
    public static class Actions
    {
        public static void FillPaymentForm(IWebDriver driver, string firstName, string lastName, string email, string address1, string postalCode, string city, string emailConfirm, string mobileNo)
        {
            IWebElement firstNameField = driver.FindElement(By.Id("travellerFirstName"));
            firstNameField.SendKeys(firstName);

            IWebElement lastNameField = driver.FindElement(By.Id("travellerLastName"));
            lastNameField.SendKeys(lastName);

            IWebElement emailField = driver.FindElement(By.Id("travellerEmailAddress"));
            emailField.SendKeys(email);

            IWebElement address1Field = driver.FindElement(By.Id("travellerAddress1"));
            address1Field.SendKeys(address1);

            IWebElement travellerPostalCodeField = driver.FindElement(By.Id("travellerPostalCode"));
            travellerPostalCodeField.SendKeys(postalCode);

            IWebElement travellerCityField = driver.FindElement(By.Id("travellerCity"));
            travellerCityField.SendKeys(city);

            IWebElement emailFieldConfirm = driver.FindElement(By.Id("travellerConfirmEmailAddress"));
            emailFieldConfirm.SendKeys(emailConfirm);

            IWebElement mobileNoField = driver.FindElement(By.Id("travellerPhoneNumber"));
            mobileNoField.Clear();
            mobileNoField.SendKeys(mobileNo);
        }        

    }
}