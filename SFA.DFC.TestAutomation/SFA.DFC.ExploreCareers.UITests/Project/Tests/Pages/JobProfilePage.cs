using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobProfilePage : BasePage
    {

        private ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        protected override string PageTitle => "";
        private string JobProfileSelected;

        public JobProfilePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyCorrectJobProfilePage()
        {
            _context.TryGetValue("JCProfileSelected", out JobProfileSelected);
            _pageHelper.VerifyText(PageHeader, JobProfileSelected);
        }

    }
}
