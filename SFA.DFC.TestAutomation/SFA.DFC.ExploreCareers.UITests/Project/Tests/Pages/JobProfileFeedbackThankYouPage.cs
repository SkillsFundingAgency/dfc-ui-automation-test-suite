using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobProfileFeedbackThankYouPage : BasePage
    {
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        protected override string PageTitle => "";
        private By ThankYouMessage => By.ClassName("headig-small");
        public JobProfileFeedbackThankYouPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyThankYouMessage()
        {
            _pageHelper.VerifyText(ThankYouMessage, "Thanks");
        }

    }
}
