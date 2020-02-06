using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class MoreJobsPage : BasePage 
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
        private readonly By ButtonSearch = By.Id("EnterJobButtonSearch");
        private readonly By ErrorSummary = By.Id("errorsummary");
        private readonly By ErrorMsg = By.Id("errormsg");
        #endregion

        public MoreJobsPage(ScenarioContext context): base(context)
        {
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }


        public MoreJobsPage EnterJob(string job)
        {
            _objectContext.Set("searchedTerm", job);
            _formHelper.EnterText(TextEntryJob, job);
            System.Threading.Thread.Sleep(2000);
            _pageHelper.IsElementPresent(DropdownResults).Should().BeTrue();
            return this;
        }

        public MoreJobsPage SelectJob(string job)
        {
            List<IWebElement> list = _pageHelper.FindElements(DropdownResults);
            for (var i = 0; i < list.Count; i++)
                if (_pageHelper.GetText(list[i]).ToString() == job)
                {
                    _formHelper.ClickElement(list[i]);
                }
                        
            return this;
        }

        public MoreJobsPage ClickSearch()
        {
            _formHelper.ClickElement(ButtonSearch);
            return this;
        }

        public MoreJobsPage VerifyError()
        {
            _pageHelper.IsElementDisplayed(ErrorSummary).Should().BeTrue();
            _pageHelper.IsElementDisplayed(ErrorMsg).Should().BeTrue();
            return this;
        }


    }
}
