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
    public class ThankYouForContactingUsSteps
    {
        private readonly ScenarioContext _context;
        private ThankYouForContactingUsPage _thankYouForContactingUsPage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;



        public ThankYouForContactingUsSteps(ScenarioContext context)
        {
            _context = context;
            _thankYouForContactingUsPage = new ThankYouForContactingUsPage(context);
            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }

        [Then(@"the user should be presented with Thank you for contacting us page")]
        public void ThenTheUserShouldBePresentedWithThankYouForContactingUsPage()
        {
            _thankYouForContactingUsPage.VerifyPage();
        }




    }
}
