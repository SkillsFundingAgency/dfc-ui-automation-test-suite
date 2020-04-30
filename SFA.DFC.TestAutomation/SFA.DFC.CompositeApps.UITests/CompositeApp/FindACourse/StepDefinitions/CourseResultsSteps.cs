using OpenQA.Selenium;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Pages;
using SFA.DFC.CompositeApps.UITests.Config;
using SFA.DFC.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.StepDefinitions
{
    [Binding]
    public class CourseResultsSteps
    {
        private readonly ScenarioContext _context;
        private CourseResultsPage courseResultsPage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;

        public CourseResultsSteps(ScenarioContext context)
        {
            _context = context;
            courseResultsPage = new CourseResultsPage(context);
            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
        }

        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string searchTerm)
        {
            
        }

        [Given(@"I am on the find a course page")]
        public void GivenIAmOnTheFindACoursePage()
        {
            _webDriver.Url = _config.BaseUrl + "/find-a-course";
            courseResultsPage.VerifyPage();
        }
    }
}
