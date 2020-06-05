using DFC.TestAutomation.UI.TestSupport;
using SFA.DFC.ContactUs.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;


namespace SFA.DFC.ContactUs.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SelectAnOptionSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion 
        #region pages
        private ContactUsHomePage contactUsHomePage;
        private SelectAnOptionPage selectAnOptionPage;
        private FirstContactFormPage firstContactFormPage;
        private ReportaTechnicalIssuePage reportaTechnicalIssuePage;
        #endregion 
        public SelectAnOptionSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            contactUsHomePage = new ContactUsHomePage(_context);
            selectAnOptionPage = new SelectAnOptionPage(_context);

        }
        [Given(@"I have selected '(.*)' option to continue onto the first contact form")]        
        public void GivenIHaveSelectedOptionToContinueOntoTheFirstContactForm(string option)
        {

            selectAnOptionPage = contactUsHomePage
                .NavigateToContactUsPage()
                .ClickOnlineMessageLink()
                .SelectContactOption(option);
            if (_objectContext.Get("SelectOption") != "Report a technical issue")
            {
                firstContactFormPage = selectAnOptionPage.ClickContinue();
            }
            else
            {
                reportaTechnicalIssuePage = selectAnOptionPage.ClickContinueTechnical();
            }
        }
        #region Thens
        [Then(@"I am directed to the first contact form")]
        public void ThenIAmDirectedToTheFirstContactForm()
        {
            firstContactFormPage.VerifyQueryPage();
        }
        [Then(@"I am redirected to the first technical contact form")]
        public void ThenIAmRedirectedToTheFirstTechnicalContactForm()
        {
            reportaTechnicalIssuePage.VerifyTechnicalPage();
        }
        #endregion
    }

}
