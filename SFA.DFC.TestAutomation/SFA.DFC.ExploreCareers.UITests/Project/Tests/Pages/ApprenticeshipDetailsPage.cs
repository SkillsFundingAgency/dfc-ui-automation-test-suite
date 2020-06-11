using FluentAssertions;
using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class ApprenticeshipDetailsPage : BasePage
    {
        #region Helpers
        private ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ObjectContext _objectContext;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By AppVacancyId => By.Id("vacancy-title");

        private By NoApprenticeshipText => By.ClassName("heading-xlarge");

        #endregion

        public ApprenticeshipDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public void VerifyCorrectApprenticeshipPage()
        {
            string AppSelected = _objectContext.Get("ApprenticeshipSelected");
            bool Result = false;
            if (_pageHelper.IsElementDisplayed(AppVacancyId))
            {
               Result = _pageHelper.VerifyText(AppVacancyId, AppSelected);
            }
            else if (_pageHelper.IsElementDisplayed(NoApprenticeshipText))
            {
               Result = _pageHelper.VerifyText(NoApprenticeshipText, "Apprenticeship no longer available");
            }

            Result.Should().BeTrue();
            
        }
    }
}
