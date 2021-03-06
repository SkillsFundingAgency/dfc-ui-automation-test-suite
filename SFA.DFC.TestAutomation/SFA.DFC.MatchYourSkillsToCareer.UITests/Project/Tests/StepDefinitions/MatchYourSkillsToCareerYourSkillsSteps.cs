﻿using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerYourSkillsSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private SkillsListPage skillsListPage;
       
        #endregion
        public MatchYourSkillsToCareerYourSkillsSteps(ScenarioContext context)
        {
            _context = context;
            skillsListPage = new SkillsListPage(_context);
        }

        #region When

        [When(@"I click on Add More Skills on Your skills list page")]
        public void WhenIClickOnSearchForSkillsOnTheYourSkillsListPage()
        {
            skillsListPage
                .AddMoreSkills();
        }


        [When(@"I click remove selected skill")]
        public void WhenIClickRemoveSelectedSkill()
        {
            skillsListPage
                .RemoveSkills();
        }

        [When(@"I select continue to your career matches")]
        public void WhenISelectContinueToYourCareerMatches()
        {
            skillsListPage
                .ContinueToCareerMatches();
        }

        #endregion

        #region Then

        [Then(@"I am taken to the Your skills list page")]
        public void ThenIAmTakenToTheYourSkillsListPage()
        {
            skillsListPage = new SkillsListPage(_context);
        }

        #endregion


    }
}
