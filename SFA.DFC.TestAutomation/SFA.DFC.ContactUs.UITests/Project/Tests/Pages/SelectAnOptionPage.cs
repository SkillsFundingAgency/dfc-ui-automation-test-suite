using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class SelectAnOptionPage : BasePage 
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By OptionPageTitle = By.CssSelector(".govuk-fieldset__heading");
        private By ContactAdviser = By.CssSelector("#ContactOptionType_ContactAdviser");
        private By TechnicalIssue = By.Id("ContactOptionType_Technical");
        private By Feedback = By.Id("ContactOptionType_Feedback");
        private By ContinueButton = By.Id("show-basic-details");
        #endregion 
        public SelectAnOptionPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            VerifyOptionPage();
        }
        public SelectAnOptionPage SelectContactOption(string strOption)
        {
            if (strOption == "Contact an adviser")
            {
                _formHelper.SelectRadioButton(ContactAdviser);
            }
            else if (strOption == "Report a technical issue")
            {
                _formHelper.SelectRadioButton(TechnicalIssue);
            }
            else if (strOption == "Give feedback")
            {
                _formHelper.SelectRadioButton(Feedback);
            }
            _objectContext.Set("SelectOption", strOption);
            return this;
        }
        public void VerifyOptionPage()
        {
            _pageHelper.VerifyPage(OptionPageTitle, "Why would you like to contact us?");
        }
        public FirstContactFormPage ClickContinue()
        {
             _formHelper.ClickElement(ContinueButton);
             return new FirstContactFormPage(_context);           
           
        }
        public ReportaTechnicalIssuePage ClickContinueTechnical()
        {
            _formHelper.ClickElement(ContinueButton);
            return new ReportaTechnicalIssuePage(_context);
        }
        
    }
}
