using TechTalk.SpecFlow;
using SFA.DFC.ContactUs.UITests.Project.Tests.Pages;

namespace SFA.DFC.ContactUs.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FirstContactFormSteps
    {
        private readonly ScenarioContext _context;
        #region Pages
        private FirstContactFormPage firstContactFormPage;
        private EnterDetailsPage enterDetailsPage;
        #endregion
        
        public FirstContactFormSteps(ScenarioContext context)
        {
            _context = context;
            firstContactFormPage = new FirstContactFormPage(_context);
        }
        #region Whens
        [When(@"I complete the first form with '(.*)' option and '(.*)' query")]
        public void WhenICompleteTheFirstFormWithOptionAndQuery(string option, string message)
        {

            enterDetailsPage = firstContactFormPage
                    .SelectQueryOption(option)
                    .EnterQuery(message)
                    .ClickContinueFirstForm()
                    .VerifyDetailsPage();
        }
        [When(@"I press continue with nothing selected")]
        public void WhenIPressContinueWithNothingSelected()
        {
            firstContactFormPage.ClickContinueonError();
        }
        #endregion
        [Then(@"an error message is displayed on the first form")]
        public void ThenAnErrorMessageIsDisplayedOnTheFirstForm()
        {
            firstContactFormPage.VerifyErrorMessages();
        }
    }
}
