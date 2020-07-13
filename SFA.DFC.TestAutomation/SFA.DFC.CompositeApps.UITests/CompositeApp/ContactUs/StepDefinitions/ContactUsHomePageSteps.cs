using OpenQA.Selenium;
using SFA.DFC.CompositeApps.UITests.CompositeApp.ContactUs.Pages;
using SFA.DFC.CompositeApps.UITests.Config;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.ContactUs.StepDefinitions
{
    [Binding]
    public class ContactUsHomePageSteps
    {
        private readonly ScenarioContext _context;
        public ContactUsHomePage _contactUsHomePage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;

        public ContactUsHomePageSteps(ScenarioContext context)
        {
            _context = context;
            _contactUsHomePage = new ContactUsHomePage(context);
            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }


        [Given(@"I am on the contact us homepage")]
        public void GivenIAmOnTheContactUsHomepage()
        {
            _webDriver.Url = _config.BaseUrl + "/contact-us";

            _contactUsHomePage.VerifyPage();
            _contactUsHomePage.AcceptCookies();

        }

        [Then(@"I am presented with the four options")]
        public void ThenIAmPresentedWithTheFourOptions()
        {
           var optionsCount=  _contactUsHomePage.GetOptionsCount();

            Assert.AreEqual(optionsCount, 4);

        }

        [When(@"I click continue with nothing selected")]
        public void WhenIClickContinueWithNothingSelected()
        {
            _contactUsHomePage.ClickContinueButton();
        }


        [Then(@"an error message is displayed on the homepage")]
        public void ThenAnErrorMessageIsDisplayedOnTheHomepage()
        {
            _contactUsHomePage.VerifyErrorSummary();
        }

    }
}
