using System;
using BoDi;
using Flurl;
using OpenQA.Selenium;

namespace Driver_AutoTests.TestContext
{
    public class PageContext
    {
        private readonly IObjectContainer _objectContainer;
        

        public PageContext(
            IObjectContainer objectContainer,
            IWebDriver webDriver)
        {
            _objectContainer = objectContainer;
            Driver = webDriver;
        }

        public IWebDriver Driver { get; set; }

        public T GetPageContent<T>()
        {
            return _objectContainer.Resolve<T>();
        }

        public Lazy<T> GetLazyPageContent<T>()
        {
            return new Lazy<T>(GetPageContent<T>);
        }

        public string GetPath(string relativePagePath)
        {
            return ApplicationSettings.HomePath.AppendPathSegment(relativePagePath);
        }
    }
}