﻿using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class DYSACAssessmentCompletePage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By ResultsButton = By.XPath(".//*[@id='main-content']/div/div/a");


        #endregion

        public DYSACAssessmentCompletePage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }


        public DYSACResultsPage ClickResultsButton()
        {
            _formHelper.ClickElement(ResultsButton);
            return new DYSACResultsPage(_context);
        }

    }
}
