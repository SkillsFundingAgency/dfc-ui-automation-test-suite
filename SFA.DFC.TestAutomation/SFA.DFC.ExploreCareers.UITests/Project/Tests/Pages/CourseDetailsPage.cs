﻿using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class CourseDetailsPage : BasePage
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        private readonly ObjectContext _objectContext;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private By CourseTitle => By.ClassName("govuk-heading-l");

        #endregion
        public CourseDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public void VerifyCorrectCourseDetailsPage()
        {
            string CourseSelectedFromJP = _objectContext.Get("CourseSelected");
            _pageHelper.VerifyText(CourseTitle, CourseSelectedFromJP).Should().BeTrue();
        }
    }
}
