using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VisitCitybreakTestExercize.Utilities
{
    public static class DriverManager
    {
        public static IWebDriver InitializeDriver()
        {
            return new ChromeDriver();
        }
    }
}
