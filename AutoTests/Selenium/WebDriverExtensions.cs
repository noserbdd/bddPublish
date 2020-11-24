using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Driver_AutoTests.Selenium
{
    public static class WebDriverExtensions
    {

        private const string PageInitializedAttrName = "data-selenium-page-initialized";

        public static void WaitForPageLoadCompleted(this IWebDriver webDriver)
        {
            bool pageLoadScriptExecuted = false;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                if (d.TryFindElement(By.XPath($"/html/body[@{PageInitializedAttrName}='true']")) != null)
                    return true;

                if (pageLoadScriptExecuted)
                    return false;

                pageLoadScriptExecuted = true;

                bool isInitialized = (bool)((IJavaScriptExecutor) d).ExecuteScript(@"
                    if (typeof jQuery == 'undefined') { 
                        return true; 
                    }
                    
                    var newScript = document.createElement('script');
                    var inlineScript = document.createTextNode(""$(document).ready(function(){ $(document.body).attr('" + PageInitializedAttrName + @"', 'true'); });"");
                    newScript.appendChild(inlineScript);
                    document.body.appendChild(newScript);
                    return false;");
                return isInitialized;
            });
        }
    }
}
