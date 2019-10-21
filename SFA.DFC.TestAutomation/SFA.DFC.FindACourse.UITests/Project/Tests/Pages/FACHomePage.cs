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
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By CourseNameSearchTerm = By.Id("SearchTerm");
        private By FACHeader = By.CssSelector(".govuk-heading-xl");
    
       // '.govuk-heading-xl
        private By ProviderName = By.Id("Provider");
        private By Location = By.Id("Location");
        private By Courses1619=By.Id("Only1619Courses");
        private By FindACourseButton = By.CssSelector(".govuk-button");


        #endregion
        public FACHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            VerifyPageHeader();
        }
        public void EnterLocation(string strLocation)
        {
            _formHelper.EnterText(Location,strLocation);           
        }
        public void EnterProvider(string strProv)
        {
            _formHelper.EnterText(ProviderName, strProv);            
        }
        public void  VerifyPageHeader()
        {
            _pageHelper.VerifyText(FACHeader, "Find a course");            
        }

        public CourseSearchPage ClickFindACourse()
        {
            _formHelper.ClickElement(FindACourseButton);
            return new CourseSearchPage(_context);
        }

        public void EnterSearchCriteria(string strCourseName)
        {
            _formHelper.EnterText(CourseNameSearchTerm, strCourseName);            
        }

    }
}
