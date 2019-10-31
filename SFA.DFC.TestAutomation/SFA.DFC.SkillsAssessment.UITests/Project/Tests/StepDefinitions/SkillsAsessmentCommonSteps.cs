using OpenQA.Selenium;
using SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SkillsAsessmentCommonSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private SHCHomePage shcHomePage;
        private SkillsAssessmentHomePage skillAssessmentHomepage;
        private YourAssessmentsPage yourAssessmentsPage;
       
        #endregion
        public SkillsAsessmentCommonSteps(ScenarioContext context)
        {
            _context = context;
            skillAssessmentHomepage = new SkillsAssessmentHomePage(_context);            
        }
        [Given(@"I have navigated to the Skills Health check page")]
        public void GivenIHaveNavigatedToTheSkillsHealthCheckPage()
        {
            shcHomePage= skillAssessmentHomepage.NavigatetoSHCHomePage()
                .ClickGoToSHC();
            yourAssessmentsPage= shcHomePage.ClickNewHealthCheck();
        }
       
    }
}
