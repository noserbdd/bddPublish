using OpenQA.Selenium;
using Driver_AutoTests.TestContext;
using System;

namespace Driver_AutoTests.PageObjects.Common
{

    class SideMenue : PageCommonCompentsBase

   {
        private readonly IWebDriver _webDriver;

        private readonly string _rootSideElement = "//div[contains(@class,'MuiDrawer-root')]"; 

        public SideMenue(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void navigateToSideMenueItem(String item) 
        {
            IWebElement sideMenueElement = _webDriver.FindElement(By.XPath($"{_rootSideElement}//span[contains(text(),\'{item}\')]"));
            sideMenueElement.Click();
        }
    }
}
