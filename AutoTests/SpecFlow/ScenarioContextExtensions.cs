using Driver_AutoTests.Factories;
using Driver_AutoTests.PageObjects;
using Driver_AutoTests.PageObjects.Common;
using Driver_AutoTests.Resources;
using Driver_AutoTests.TestContext;
using TechTalk.SpecFlow;

namespace Driver_AutoTests.Specflow
{
    public static class ScenarioContextExtensions
    {
        public static T GetPage<T>(this ScenarioContext scenarioContext) where T : PageBase
        {
            return scenarioContext.ScenarioContainer.Resolve<IPageFactory>().GetPage<T>();
        }

        public static T GetPageCompent<T>(this ScenarioContext scenarioContext) where T : PageCommonCompentsBase
        {
            return scenarioContext.ScenarioContainer.Resolve<T>();
        }

        public static void SetUser(this ScenarioContext scenarioContext, Users user)
        {
            scenarioContext.ScenarioContainer.Resolve<UserContext>().SetCurrentUser(user);
        }

        public static T GetCurrentUserData<T>(this ScenarioContext scenarioContext, object dataKey = null)
        {
            return scenarioContext.ScenarioContainer.Resolve<UserContext>().GetCurrentUserData<T>(dataKey);
        }

    }
}