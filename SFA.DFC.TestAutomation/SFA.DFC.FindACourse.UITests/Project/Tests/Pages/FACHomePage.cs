using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.Pages
{
    public class FACHomePage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly FindACourseConfig _config;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By CourseNameSearchTerm = By.Id("SearchTerm");
        private By FACHeader = By.CssSelector(".govuk-heading-xl");  
        private By ProviderName = By.Id("Provider");
        private By Location = By.Id("Location");
        private By FindACourseButton = By.CssSelector(".sf_colsIn .govuk-button");
        #endregion
        public FACHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetFindACourseConfig<FindACourseConfig>();
            _webDriver = context.GetWebDriver();          
        }
        public FACHomePage NavigateToFACHomepage()
        {
            _webDriver.Url = _config.BaseUrl + "/find-a-course/search";
            return this;
        }
        public FACHomePage EnterLocation(string strLocation)
        {
            _formHelper.EnterText(Location,strLocation);
            _objectContext.Set("LocationName", strLocation);
            return this;
        }
        public FACHomePage EnterProvider(string strProv)
        {             
            _formHelper.EnterText(ProviderName, strProv);
            _objectContext.Set("ProvName", strProv);
            return this;
        }
       
        public CourseResultsPage ClickFindACourse()
        {
            _formHelper.ClickElement(FindACourseButton);
            return new CourseResultsPage(_context);
        } 
        public FACHomePage EnterSearchCriteria(string strCourseName)
        {
            _objectContext.Set("CourseName", strCourseName);
            _formHelper.EnterText(CourseNameSearchTerm, strCourseName);
            return this;
        }
    }
}
