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
    public class SpeakToAnAdviserSteps
    {
        private readonly ScenarioContext _context;
        private ContactUsHomePage _contactUsHomePage;
        private SpeakToAnAdviserPage _speakToAnAdviserPage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;



        public SpeakToAnAdviserSteps(ScenarioContext context)
        {
            _context = context;
            _contactUsHomePage = new ContactUsHomePage(context);
            _speakToAnAdviserPage = new SpeakToAnAdviserPage(context);

            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }
        [When(@"the user chooses the option chat online")]
        public void WhenTheUserChoosesTheOptionChatOnline()
        {
            _contactUsHomePage.ChatOnline();
            _speakToAnAdviserPage.VerifyPage();
        }
    }
}
