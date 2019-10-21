using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class CourseDetailsPage : BasePage
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        #endregion

        #region Page attributes
        protected override string PageTitle => "";
        private string CourseSelectedFromJP;
        private By CourseTitle => By.ClassName("govuk-heading-l");

        #endregion
        public CourseDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyCorrectCourseDetailsPage()
        {
            _context.TryGetValue("CourseSelected", out CourseSelectedFromJP);
            _pageHelper.VerifyText(CourseTitle, CourseSelectedFromJP);
        }
    }
}
