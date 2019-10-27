using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class FirstContactFormPage : BasePage 
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By QueryPageTitle = By.CssSelector(".govuk-fieldset__heading");
        private By Message = By.Id("Message");
        private By Feedback = By.Id("Feedback");
        private By ContinueButton = By.Id("send-feedback-details");
        



        private List<IWebElement> OptionsList => _pageHelper.FindElements(By.ClassName("govuk-radios__input"));
        #endregion
        public FirstContactFormPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }
        public void VerifyQueryPage()
        {
            if (_objectContext.Get("SelectOption") == "Contact an adviser")
            {
                _pageHelper.VerifyText(QueryPageTitle, "What is your query about?");
            }
            else if (_objectContext.Get("SelectOption") == "Give feedback")
            {
                _pageHelper.VerifyText(QueryPageTitle, "What is your feedback about?");
            }
        }

       public FirstContactFormPage SelectQueryOption(string strOption)
        {
            {
                if (!string.IsNullOrWhiteSpace(strOption))
                {
                    var OptionText = strOption.Replace(" ", string.Empty).ToUpper();
                    foreach (var button in OptionsList)
                    {
                        var buttonText = button.GetAttribute("value").Replace(" ", string.Empty).ToUpper();
                        if (buttonText.Contains(OptionText))
                        {
                            button.Click();
                        }
                    }
                }
                return this;
            }
        }
        public void EnterQuery(string strQuery)
        {
            if (_objectContext.Get("SelectOption") == "Contact an adviser")
            {
                _formHelper.EnterText(Message, strQuery);
            }
            else if (_objectContext.Get("SelectOption") == "Give feedback")
            {
                _formHelper.EnterText(Feedback, strQuery);
            }

        }
        public EnterDetailsPage ClickContinueFirstForm()
        {
            _formHelper.ClickElement(ContinueButton);
            return new EnterDetailsPage(_context);
        }
        


    }
}
