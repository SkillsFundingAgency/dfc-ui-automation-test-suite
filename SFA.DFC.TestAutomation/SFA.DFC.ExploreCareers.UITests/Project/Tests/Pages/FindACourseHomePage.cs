using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class FindACourseHomePage : BasePage
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private By Header => By.ClassName("govuk-heading-xl");
        #endregion

        public FindACourseHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyFindACourseHomepage()
        {
            _pageHelper.VerifyText(Header, "Find a course");
        }

    }
}
