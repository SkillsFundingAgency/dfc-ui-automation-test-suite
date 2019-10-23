using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
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
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By CourseNameSearchTerm = By.Id("SearchTerm");
        private By FACHeader = By.CssSelector(".govuk-heading-xl");  
        private By ProviderName = By.Id("Provider");
        private By Location = By.Id("Location");
        private By FindACourseButton = By.CssSelector(".govuk-button");
        #endregion
        public FACHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            VerifyPageHeader();
        }
        public void EnterLocation(string strLocation)
        {
            _formHelper.EnterText(Location,strLocation);
            _objectContext.Set("LocationName", strLocation);           
        }
        public void EnterProvider(string strProv)
        {
            _formHelper.EnterText(ProviderName, strProv);
            _objectContext.Set("ProvName", strProv);
        }
        public void  VerifyPageHeader()
        {
            _pageHelper.VerifyText(FACHeader, "Find a course");            
        }
        public CourseResultsPage ClickFindACourse()
        {
            _formHelper.ClickElement(FindACourseButton);
            return new CourseResultsPage(_context);
        }
        public void EnterSearchCriteria(string strCourseName)
        {
            _objectContext.Set("CourseName", strCourseName);
            _formHelper.EnterText(CourseNameSearchTerm, strCourseName);
            
        }
    }
}
