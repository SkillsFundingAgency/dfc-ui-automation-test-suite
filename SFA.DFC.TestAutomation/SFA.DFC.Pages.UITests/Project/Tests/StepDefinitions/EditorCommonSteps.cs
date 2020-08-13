using OpenQA.Selenium;
using SFA.DFC.Pages.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.Pages.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EditorCommonSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;

        private EditorPages editorPages;
        #endregion

        public EditorCommonSteps(ScenarioContext context)
        {
            _context = context;
            editorPages = new EditorPages(_context);
        }

        #region Givens
        [Given(@"I have naviagted to the service taxonomy editor")]
        public void GivenIHaveNavigatedToSTAX()
        {
            editorPages
                .NavigateToSTAXEditor()
                .EnterUserDetails()
                ;
        }

        [Given(@"I have created a draft page")]
        public void GivenIHaveCreatedADraftPage()
        {
            editorPages
                .NavigateToCreatePage()
                .CreateAPage()
                .SaveDraft()
                ;
        }

        [Given(@"I have created a published page")]
        public void GivenIHaveCreatedAPublishedPage()
        {
            editorPages
                .NavigateToCreatePage()
                .CreateAPage()
                .Publish()
                ;
        }

        #endregion

        #region Whens

        [When(@"I unpublish the page")]
        public void WhenIUnpublishThePage()
        {
            editorPages
                .NavigateToManageContent()
                .UnPublish()
                ;
        }

        #endregion

        #region Thens

        #endregion
    }
}

