using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using System.Linq;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.ContactUs.Pages
{
    public class ThankYouForContactingUsPage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly FormCompletionHelper _retry;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "Thank you for contacting us | Contact us | National Careers Service";
        protected override By PageHeader => By.ClassName("govuk-fieldset__heading");


        public ThankYouForContactingUsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }
    }
}
