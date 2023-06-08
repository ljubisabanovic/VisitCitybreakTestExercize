using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace VisitCitybreakTestExercize
{
    internal class TestPage
    {
        private IWebDriver driver;
        private string url = "https://online3-next.citybreak.com/258246579/en/en-us/to-do/2208286/abba-experience/showdetails";

        public TestPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToOnline3TestCitybreak()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
