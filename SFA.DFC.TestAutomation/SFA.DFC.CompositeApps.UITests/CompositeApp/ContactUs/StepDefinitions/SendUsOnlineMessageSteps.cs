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
    public class SendUsOnlineMessageSteps
    {
        private readonly ScenarioContext _context;
        private ContactUsHomePage _contactUsHomePage;
        private SendUsOnlineMessagePage _sendUsOnlineMessagePage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;



        public SendUsOnlineMessageSteps(ScenarioContext context)
        {
            _context = context;
            _contactUsHomePage = new ContactUsHomePage(context);
            _sendUsOnlineMessagePage = new SendUsOnlineMessagePage(context);

            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"the user chooses the option Send us an online message")]
        public void WhenTheUserChoosesTheOptionSendUsAnOnlineMessage()
        {
            _contactUsHomePage.ChooseOnlineMessageOption();

            _contactUsHomePage.ClickContinueButton();
        }
        
        [When(@"the user chooses the option ask us to call you back")]
        public void WhenTheUserChoosesTheOptionAskUsToCallYouBack()
        {
            _contactUsHomePage.CallBackOption();
        }


        [Then(@"the user is presented with why do you want to contact us page")]
        public void ThenTheUserIsPresentedWithWhyDoYouWantToContactUsPage()
        {
            _sendUsOnlineMessagePage.VerifyPage();
            var optionsCount = _sendUsOnlineMessagePage.GetOptionsCount();
            Assert.AreEqual(optionsCount, 5);
        }

        [Then(@"the user chooses the option '(.*)'and enters more details")]
        public void ThenTheUserChoosesTheOptionAndEntersMoreDetails(string p0)
        {
            _sendUsOnlineMessagePage.ChooseWhyDoYouWantToContactUsOption();
        }

        [When(@"I click send with out filling the form")]
        public void WhenIClickSendWithOutFillingTheForm()
        {
        }

        [Then(@"an error summary is displayed with details")]
        public void ThenAnErrorSummaryIsDisplayedWithDetails()
        {
        }


    }
}
