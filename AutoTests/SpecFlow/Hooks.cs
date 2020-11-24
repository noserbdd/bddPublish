using System;
using System.Threading;
using System.Threading.Tasks;
using BoDi;
using Driver_AutoTests.Factories;
using Driver_AutoTests.Selenium;
using Driver_AutoTests.Specflow;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Driver_AutoTests.Specflow
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private static int _quitTasksCount;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            Setup_Infrastructure.Configure(_objectContainer);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("BeforeScenario called");

            DriverFactory driverFactory = _objectContainer.Resolve<DriverFactory>();
            _driver = driverFactory.CreateDriver();
            _objectContainer.RegisterInstanceAs(_driver);

            string fileName = scenarioContext.ScenarioInfo.Title.Replace(" ", string.Empty);
            fileName += DateTime.UtcNow.ToString("-yyyyMMdd_Hmm");

            string outputDirectoryName = ApplicationSettings.TestsVideoDirectory;


        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {

            }
            finally
            {
                Interlocked.Increment(ref _quitTasksCount);
                IWebDriver driver = _driver;

                // close browser instance async to allow next test to start without wait for this one to close
                Task.Run(() =>
                {
                    try
                    {
                        driver.Quit();
                        driver.Dispose();
                    }
                    finally
                    {
                        Interlocked.Decrement(ref _quitTasksCount);
                    }
                });
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {
            _driver.WaitForPageLoadCompleted();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {

            while (_quitTasksCount > 0)
            {
                Thread.Sleep(100);
            }
        }


    }
}
