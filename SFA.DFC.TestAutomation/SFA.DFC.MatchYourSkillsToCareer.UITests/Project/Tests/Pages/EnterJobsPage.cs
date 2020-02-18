using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class EnterJobsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ObjectContext _objectContext;

        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By TextEntryJob = By.Id("occupations-autocomplete");
        private readonly By DropdownResults = By.ClassName("autocomplete__option");
        private readonly By ButtonSearch = By.Id("occupationSearchGovukSecondaryButtonSearch");
        private readonly By ErrorSummary = By.Id("errorsummary");
        private readonly By ErrorMsg = By.Id("errormsg");
        #endregion

        public EnterJobsPage(ScenarioContext context): base(context)
        {
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public EnterJobsPage EnterJob(string job)
        {
            _objectContext.Set("searchedTerm", job);
            _formHelper.EnterText(TextEntryJob, job);
            System.Threading.Thread.Sleep(5000);
            _pageHelper.IsElementPresent(DropdownResults).Should().BeTrue();
            return this;
        }

        public EnterJobsPage SelectJob(string job)
        {
            List<IWebElement> list = _pageHelper.FindElements(DropdownResults);
            for (var i = 0; i < list.Count; i++)
                if (_pageHelper.GetText(list[i]).ToString() == job)
                {
                    _formHelper.ClickElement(list[i]);
                }              
            return this;
        }

        public EnterJobsPage ClickSearch()
        {
            _formHelper.ClickElement(ButtonSearch);
            return this;
        }

        public EnterJobsPage VerifyError()
        {
            _pageHelper.IsElementDisplayed(ErrorSummary).Should().BeTrue();
            _pageHelper.IsElementDisplayed(ErrorMsg).Should().BeTrue();
            return this;
        }

    }
}
