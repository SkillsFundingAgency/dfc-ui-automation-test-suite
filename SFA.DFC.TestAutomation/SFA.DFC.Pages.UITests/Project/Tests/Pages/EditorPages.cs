using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.Pages.UITests.Project.Tests.Pages
{
    public class EditorPages : BasePage
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
        private By PublishBtn => By.Name("submit.Publish");
        private By ActionsDropdown => By.CssSelector(".list-group-item:nth-child(2) .btn-secondary");
        private By UnpublishLink => By.LinkText("Unpublish");
        private By ModalOKBtn => By.Id("modalOkButton");
        private By JobCategoryList => By.CssSelector(".homepage-jobcategories li a");
        private By SearchField => By.ClassName("search-input");
        private By SubmitSearch => By.ClassName("submit");
        private By AutoSuggestList => By.ClassName("ui-menu-item");

        private By PageHeader => By.Id("site-header");
        private By NcsPageHeader => By.ClassName("govuk-heading-xl");


        #endregion

        public EditorPages(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetExploreCareersConfig<PagesConfig>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();
         
        }

        public EditorPages NavigateToSTAXEditor()
        {
            _webDriver.Url = _config.EditorUrl;
            return this;
        }


        public EditorPages EnterUserDetails()
        {
            _formHelper.EnterText(Username, _config.EditorUid);
            _formHelper.EnterText(Password, _config.EditorPassword);
            _formHelper.ClickElement(LoginBtn);
            return this;
        }

        public EditorPages NavigateToCreatePage()
        {
            _webDriver.Url = _config.EditorUrl + "/Admin/Contents/ContentTypes/Page/Create";
              return this;
        }

        public EditorPages NavigateToManageContent()
        {
            _webDriver.Url = _config.EditorUrl + "Admin/Contents/ContentItems?";
            System.Threading.Thread.Sleep(2000);
            return this;
        }

        public EditorPages CreateAPage()
        {
            
            _objectContext.Set("title", _randomDataGenerator.GenerateRandomAlphabeticString(15));
            _formHelper.EnterText(Title, _objectContext.Get("title"));
            var element = _webDriver.FindElement(By.Id("Page_PageLocations_TermEntries_0__Selected"));
            Actions builder = new Actions(_webDriver);
                var mouseUp = builder.MoveToElement(element)
                                      .Click()
                                      .Build(); ;
                    mouseUp.Perform();
            System.Threading.Thread.Sleep(5000);
            _formHelper.ClickElement(By.XPath("//button[@title='Add Widget']"));

            _formHelper.ClickElement(By.LinkText("HTML"));

            _pageHelper.IsElementDisplayed((By.ClassName("trumbowyg-editor")));

            _formHelper.EnterText(HMTLEditor, _objectContext.Get("title"));

            return this;

        }

        public EditorPages SaveDraft()
        {
            _formHelper.ClickElement(SaveDraftBtn);
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public EditorPages Publish()
        {
            _formHelper.ClickElement(PublishBtn);
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public EditorPages UnPublish()
        {
            _formHelper.ClickElement(ActionsDropdown);
            _formHelper.ClickElement(UnpublishLink);
            _formHelper.ClickElement(ModalOKBtn);

            System.Threading.Thread.Sleep(5000);
            return this;
        }


    }
}
