using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.Pages.UITests.Project.Tests.Pages
{
    public class PagesAppPages : BasePage
    {
        #region Helpers
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly PagesConfig _config;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";

        private By Username => By.Id("UserName");
        private By Password => By.Id("Password");
        private By LoginBtn => By.ClassName("btn-primary");
        private By Title => By.Name("TitlePart.Title");
        private By Location => By.ClassName("pl-3");
        private By HMTLEditor => By.ClassName("trumbowyg-editor");
        private By SaveDraftBtn => By.Name("submit.Save");
        private By JobCategoryList => By.CssSelector(".homepage-jobcategories li a");
        private By SearchField => By.ClassName("search-input");
        private By SubmitSearch => By.ClassName("submit");
        private By AutoSuggestList => By.ClassName("ui-menu-item");

        private By PageHeader => By.Id("site-header");
        private By NcsPageHeader => By.ClassName("govuk-heading-xl");


        #endregion

        public PagesAppPages(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetExploreCareersConfig<PagesConfig>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();
         
        }

        public PagesAppPages NavigateToDraft()
        {
            _webDriver.Url = _config.BaseUrlDraftEnv +_objectContext.Get("title");
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public PagesAppPages NavigateToPublished()
        {
            _webDriver.Url = _config.BaseUrlPublishedEnv + _objectContext.Get("title");
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public PagesAppPages PageFound()
        {
            if (_webDriver.Title.Contains(_objectContext.Get("title")))
            {
                return this;
            }
            else
            {
                throw new NotFoundException("Page not found");
            }
                
        }

        public PagesAppPages PageNotFound()
        {
            if (!_webDriver.Title.Contains(_objectContext.Get("title")))
            {
                return this;
            }
            else
            {
                throw new NotFoundException("Draft Page has published");
            }

        }

    }
}
