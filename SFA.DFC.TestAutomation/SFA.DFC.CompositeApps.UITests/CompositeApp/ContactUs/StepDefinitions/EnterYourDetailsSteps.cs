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
    public class EnterYourDetailsSteps
    {
        private readonly ScenarioContext _context;
        private EnterYourDetailsPage _enterYourDetailsPage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;



        public EnterYourDetailsSteps(ScenarioContext context)
        {
            _context = context;
            _enterYourDetailsPage = new EnterYourDetailsPage(context);
            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }

        
        [Then(@"the user enters the personal details")]
        public void ThenTheUserEnterThePersonalDetails()
        {
            _enterYourDetailsPage.VerifyPage();

            _enterYourDetailsPage.EnterDetails();
        }

        //[When(@"the user enters the personal details with the preferred call back time")]
        //public void WhenTheUserEntersThePersonalDetailsWithThePreferredCallBackTime()
        //{
        //    //_enterYourDetailsPage.VerifyPage();

        //    _enterYourDetailsPage.EnterCallBackDetails();
        //}

        [Then(@"the user enters the personal details with the preferred call back time")]
        public void ThenTheUserEntersThePersonalDetailsWithThePreferredCallBackTime()
        {
            //_enterYourDetailsPage.VerifyPage();

            _enterYourDetailsPage.EnterCallBackDetails();
        }


    }
}
