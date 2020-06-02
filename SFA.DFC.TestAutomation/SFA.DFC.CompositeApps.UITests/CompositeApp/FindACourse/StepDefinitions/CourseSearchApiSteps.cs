using OpenQA.Selenium;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.API;
using SFA.DFC.CompositeApps.UITests.Config;
using SFA.DFC.UI.Framework.TestSupport;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Linq;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.StepDefinitions
{
    [Binding]
    public class CourseSearchApiSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private CourseSearchApi _courseSearchApi;
        private readonly ObjectContext _objectContext;

        public CourseSearchApiSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _courseSearchApi = new CourseSearchApi(context);
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"I make a request to the course search API with the keyword parameter '(.*)'")]
        public async Task GivenIMakeARequestToTheCourseSearchAPIWithTheKeywordParameter(string keyword)
        {
            var response = await _courseSearchApi.ExecuteRequest();
            _objectContext.Set("TotalResults", response.Data.total);

            var test = response.Data.results.Where(result => result.startDate == null);
        }
    }
}
