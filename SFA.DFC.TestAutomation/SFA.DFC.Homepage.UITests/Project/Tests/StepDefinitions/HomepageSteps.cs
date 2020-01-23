using OpenQA.Selenium;
using SFA.DFC.Homepage.UITests.Project.Tests.Pages;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class HomepageSteps
    {
        private ScenarioContext _context;
        private HomePage homepage;
        private ServiceStatusPage statusPage;
        private PrivacyAndCookiesPage privacyAndCookiesPage;
        private TermsAndConditionsPage termsAndConditionsPage;
        private HelpPage helpPage;
        private InformationSourcesPage informationSourcesPage;
        public HomepageSteps(ScenarioContext context)
        {
            _context = context;
            homepage = new HomePage(_context);
        }

        #region Givens
        [Given(@"that I am viewing the Home page")]
        public void GivenThatIAmViewingTheHomePage()
        {
            homepage = homepage
                .NavigateToHomepage();
        }

        [Given(@"I navigate to the service status page")]
        public void GivenINavigateToTheHealth_StatusPage()
        {
            statusPage = homepage
                .NavigateToServiceStatusPage();
        }

        #endregion

        #region Whens
        [When(@"I click the Privacy link")]
        public void WhenIClickThePrivacyLink()
        {
            privacyAndCookiesPage = homepage
                .ClickPrivacyLink();
        }

        [When(@"I click the T&C link")]
        public void WhenIClickTheTCLink()
        {
            termsAndConditionsPage = homepage
                .ClickTandCLink();
        }

        [When(@"I click the Help link")]
        public void WhenIClickTheHelpLink()
        {
            helpPage = homepage
                .ClickHelpLink();
        }

        [When(@"I click the Information Sources link")]
        public void WhenIClickTheInformationSourcesLink()
        {
            informationSourcesPage = homepage
                .ClickInfoSourcesLink();
        }

        #endregion

        #region Thens
        [Then(@"the service status page is displayed")]
        public void ThenTheServiceStatusPageIsDisplayed()
        {
            statusPage
                .VerifyServicePageHeader()
                .VerifyAllServicesAreRunning();
        }

        [Then(@"I am redirected to the Privacy page")]
        public void ThenIAmRedirectedToThePrivacyPage()
        {
            privacyAndCookiesPage
                .VerifyPage();
        }

        [Then(@"I am redirected to the T&C page")]
        public void ThenIAmRedirectedToTheTCPage()
        {
            termsAndConditionsPage
                .VerifyPage();
        }

        [Then(@"I am redirected to the Help page")]
        public void ThenIAmRedirectedToTheHelpPage()
        {
            helpPage
                .VerifyPage();
        }

        [Then(@"I am redirected to the Information Sources page")]
        public void ThenIAmRedirectedToTheInformationSourcesPage()
        {
            informationSourcesPage
                .VerifyPage();
        }

        #endregion
    }
}
