using System;
using System.Reflection;
using Driver_AutoTests.Utils.Attributes;
using Driver_AutoTests.TestContext;
using OpenQA.Selenium;

namespace Driver_AutoTests.PageObjects
{
    public abstract class PageBase
    {

        protected readonly IWebDriver Driver;

        protected PageBase(PageContext pageContext)
        {
            Driver = pageContext.Driver;

            InitializePath(pageContext);
        }

        protected string Path { get; private set; }

        public string Title => Driver.Title;


        public virtual bool IsActive()
        {
            return Driver.Url.StartsWith(Path);
        }

        public virtual void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Path);
        }

        public void Logout()
        {

        }

        private void InitializePath(PageContext pageContext)
        {
            RelativePagePathAttribute relativePagePathAttribute = GetType().GetCustomAttribute<RelativePagePathAttribute>();
            if (relativePagePathAttribute != null)
                Path = pageContext.GetPath(relativePagePathAttribute.RelativePath);
        }
    }
}
