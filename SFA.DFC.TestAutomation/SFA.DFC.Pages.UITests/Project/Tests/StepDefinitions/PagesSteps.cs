using OpenQA.Selenium;
using SFA.DFC.Pages.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.Pages.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PagesSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private EditorPages editorPages;
        private PagesAppPages pagesAppPages;
        #endregion

        public PagesSteps(ScenarioContext context)
        {
            _context = context;
            editorPages = new EditorPages(_context);
            pagesAppPages = new PagesAppPages(_context);
        }

        #region Givens

        [Given(@"I have navigated to the draft environment")]
        public void GivenIHaveNavigatedToTheDraftEnvironment()
        {
            pagesAppPages
                .NavigateToDraft();

        }

        [Given(@"I have navigated to the published environment")]
        public void GivenIHaveNavigatedToThePublishedEnvironment()
        {
            pagesAppPages
                .NavigateToPublished();
        }


        #endregion

        #region Thens

        [Then(@"the page is found")]
        public void ThenThePageIsFound()
        {
            pagesAppPages
                .PageFound()
                ;
        }

        [Then(@"the page is not found")]
        public void ThenThePageIsNotFound()
        {
            pagesAppPages
                .PageNotFound();
        }

        #endregion

    }
}

