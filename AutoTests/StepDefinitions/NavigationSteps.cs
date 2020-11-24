using Driver_AutoTests.PageObjects;
using Driver_AutoTests.PageObjects.Common;
using Driver_AutoTests.Specflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Driver_AutoTests.StepDefinitions
{
    [Binding]
    public sealed class NavigationSteps
    {

        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

    }
}
