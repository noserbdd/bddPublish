using TechTalk.SpecFlow;

namespace AutoTests.StepDefinitions
{

    [Binding]
    public sealed class LoginSteps
    {

        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Die Loginseite wird angezeigt\.")]
        public void AngenommenDieLoginseiteWirdAngezeigt_()
        {
            ScenarioContext.Current.Pending();
        }
    }

}
