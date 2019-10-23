using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;
namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class ReportaTechnicalIssuePage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By TechnicalPageTitle = By.CssSelector(".govuk-heading-xl");
        private By Message = By.Id("Message");
        private By ContinueButton = By.CssSelector(".govuk-button");
       
        #endregion
        public ReportaTechnicalIssuePage(ScenarioContext context): base (context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            
        }
        public void VerifyTechnicalPage()
        { 
        
            _pageHelper.VerifyText(TechnicalPageTitle, "Report a technical issue");
        }
        public void EnterTechnicalQuery(string query)
        {
            _formHelper.EnterText(Message, query);
        }
        public EnterDetailsPage ClickContinueonTechnicalForm()
        {
            _formHelper.ClickElement(ContinueButton);
            return new EnterDetailsPage(_context);
        }        
    }
}
