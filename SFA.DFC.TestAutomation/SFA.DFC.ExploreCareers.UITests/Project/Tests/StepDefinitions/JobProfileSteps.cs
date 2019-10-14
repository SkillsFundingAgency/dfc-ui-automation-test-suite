using OpenQA.Selenium;
using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class JobProfileSteps
    {

        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly ProjectConfig _config;
        private JobProfilePage jobProfilePage;

        public JobProfileSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
        }
        #region Givens

        [Given(@"I navigate to the '(.*)' profile")]
        public void GivenINavigateToTheProfile(string jobProfile)
        {
            _webDriver.Url = _config.BaseUrl + "/job-profiles/" + jobProfile;
        }
        #endregion

        #region Whens
        [When(@"I click on career title '(.*)'")]
        public void WhenIClickOnCareerTitle(int careerSelected)
        {
            jobProfilePage
                .SelectRelatedCareer(careerSelected);
        }

        #endregion

        #region Thens

        [Then(@"the related careers section should be displayed")]
        public void ThenTheRelatedCareersSectionShouldBeDisplayed()
        {
            jobProfilePage = new JobProfilePage(_context);
            jobProfilePage.VerifyRelatedCareersSectionDisplayed();
        }

        [Then(@"there should be no more than (.*) careers")]
        public void ThenThereShouldBeNoMoreThanCareers(int maxNoOfRelatedProfiles)
        {
            jobProfilePage
                .VerifyNumberOfRelatedCareersDisplayed(maxNoOfRelatedProfiles);
        }

        [Then(@"I am redirected to the profile selected")]
        public void ThenIAmRedirectedToTheProfileSelected()
        {
            jobProfilePage = new JobProfilePage(_context);
            jobProfilePage.VerifyCorrectJobProfilePage();
        }
        #endregion
    }
}
