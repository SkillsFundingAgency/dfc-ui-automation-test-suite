using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class ApprenticeshipDetailsPage : BasePage
    {
        private ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        protected override string PageTitle => "";
        private string AppSelected;
        private By AppVacancyId => By.Id("vacancy-title");

        public ApprenticeshipDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyCorrectApprenticeshipPage()
        {
            _context.TryGetValue("ApprenticeshipSelected", out AppSelected);
            _pageHelper.VerifyText(AppVacancyId, AppSelected);
        }
    }
}
