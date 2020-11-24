using System;
using System.Linq;
using OpenQA.Selenium;

namespace Driver_AutoTests.Selenium
{
    public static class SearchContextExtension
    {
        public static IWebElement TryFindElement(this ISearchContext searchContext, By by)
        {
            return searchContext.FindElements(by).SingleOrDefault();
        }

        public static IWebElement FindElementUntilTimeout(this ISearchContext searchContext, By by, TimeSpan maxFindTimeSpan)
        {
            DateTime maxDateTime = DateTime.UtcNow.Add(maxFindTimeSpan);
            do
            {
                var foundElement = searchContext.FindElements(by).SingleOrDefault();
                if (foundElement != null)
                    return foundElement;
            } while (DateTime.UtcNow < maxDateTime);

            throw new Exception($"Element not found within given timeout of {maxFindTimeSpan}");
        }
    }
}
