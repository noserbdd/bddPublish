using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;

namespace Driver_AutoTests.Selenium
{
    public static class WebElementExtensions
    {
        public static IWebElement Parent(this IWebElement webElement)
        {
            return webElement.FindElement(By.XPath("./.."));
        }

        public static void WaitUntilDisplayed(this IWebElement webElement, TimeSpan timeout)
        {
            DateTime maxDateTime = DateTime.UtcNow.Add(timeout);
            do
            {
                if (webElement.Displayed)
                    return;
            } while (DateTime.UtcNow < maxDateTime);

            throw new Exception($"Element not displayed after timeout of {timeout}");
        }

        public static void WaitUntilNotDisplayed(this IWebElement webElement, TimeSpan timeout)
        {
            DateTime maxDateTime = DateTime.UtcNow.Add(timeout);
            do
            {
                if (!webElement.Displayed)
                    return;
            } while (DateTime.UtcNow < maxDateTime);

            throw new Exception($"Element still displayed after timeout of {timeout}");
        }

        public static bool IsVisibleInViewport(this IWebElement element)
        {
            IWebDriver driver = element.GetWebDriverFromElement();
            return (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                "var elem = arguments[0],                 " +
                "  box = elem.getBoundingClientRect(),    " +
                "  cx = box.left + box.width / 2,         " +
                "  cy = box.top + box.height / 2,         " +
                "  e = document.elementFromPoint(cx, cy); " +
                "for (; e; e = e.parentElement) {         " +
                "  if (e === elem)                        " +
                "    return true;                         " +
                "}                                        " +
                "return false;                            "
                , element);
        }

        public static IWebDriver GetWebDriverFromElement(this IWebElement element)
        {
            var realElement = element.GetType() != typeof(RemoteWebElement)
                ? element
                : ((IWrapsElement)element).WrappedElement;

            return ((IWrapsDriver)realElement).WrappedDriver;
        }
    }
}
