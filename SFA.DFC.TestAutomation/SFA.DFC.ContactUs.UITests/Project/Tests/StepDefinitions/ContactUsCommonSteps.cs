using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DFC.ContactUs.UITests.Project.Tests.Pages;

namespace SFA.DFC.ContactUs.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ContactUsCommonSteps
    {
        private readonly ScenarioContext _context;
        private readonly ContactUs _config;
        private readonly IWebDriver _webDriver;

        private ContactUsHomePage contactUsHomePage;
        private SelectAnOptionPage selectAnOptionPage;
        
        public ContactUsCommonSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetContactUsConfig<ContactUs>();            
        }
        [Given(@"I have navigated to the contact us page")]
        public void GivenIHaveNavigatedToTheContactUsPage()
        {
            _webDriver.Url = _config.BaseUrl + "/contact-us";
        }
        [Given(@"I have clicked the link to online message")]
        public void GivenIHaveClickedTheLinkToOnlineMessage()
        {
            contactUsHomePage = new ContactUsHomePage(_context);
            selectAnOptionPage = contactUsHomePage.ClickOnlineMessageLink();
            selectAnOptionPage.VerifyOptionPage();
        }       
    }

}
