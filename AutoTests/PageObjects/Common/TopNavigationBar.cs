using Driver_AutoTests.Resources;
using Driver_AutoTests.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Driver_AutoTests.PageObjects.Common
{
    class TopNavigationBar
    {
        private readonly IWebDriver _webDriver;

        public TopNavigationBar(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement TryGetLoginLink()
        {
            return GetHeaderElement().TryFindElement(By.ClassName("MuiButtonBase"));
        }


        private IWebElement GetHeaderElement()
        {
            return _webDriver.FindElement(By.ClassName("MuiAppBar-root"));
        }

    }
}
