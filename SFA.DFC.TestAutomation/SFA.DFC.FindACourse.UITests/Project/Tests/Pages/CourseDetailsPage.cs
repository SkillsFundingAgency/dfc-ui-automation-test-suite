using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.Pages
{
    public class CourseDetailsPage : BasePage
    {
        protected override string PageTitle => "";
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ObjectContext _objectContext;
        #endregion
        #region Page Elements
        private By CourseHeader = By.CssSelector(".govuk-heading-l");
        private By QualDetails = By.LinkText("Course details");
        private By CourseDesc = By.LinkText("Who this course is for");
        private By EntryReqs = By.LinkText("Entry requirements");
        private By WhatYoullLearn = By.LinkText("What you'll learn");
        private By HowYoullLearn = By.LinkText("How you'll learn");
        private By EquipReqd = By.LinkText("What you'll need to bring");
        private By AssessMethod = By.LinkText("How you'll be assessed");
        private By NextSteps = By.LinkText("Next steps");
        private By Venue = By.LinkText("Venue");
        private By OtherDatesandVenues = By.LinkText("Other venues and dates");
        #endregion
        public CourseDetailsPage(ScenarioContext context) : base(context)
        {
            
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }
        public void  VerifyLinks()
        {
            _pageHelper.VerifyText(QualDetails, "Course details").Should().BeTrue();
            _pageHelper.VerifyText(CourseDesc , "Who this course is for").Should().BeTrue();
            _pageHelper.VerifyText(EntryReqs , "Entry requirements").Should().BeTrue();
            _pageHelper.VerifyText(WhatYoullLearn, "What you'll learn").Should().BeTrue();
            _pageHelper.VerifyText(HowYoullLearn, "How you'll learn").Should().BeTrue();
            _pageHelper.VerifyText(EquipReqd , "What you'll need to bring").Should().BeTrue();
            _pageHelper.VerifyText(AssessMethod , "How you'll be assessed").Should().BeTrue();
            _pageHelper.VerifyText(NextSteps, "Next steps").Should().BeTrue();
            _pageHelper.VerifyText(Venue , "Venue").Should().BeTrue();
            _pageHelper.VerifyText(OtherDatesandVenues , "Other venues and dates").Should().BeTrue();            
        }
        public void VerifyIfLinksCanBeClicked()
        {
            _formHelper.ClickElement(QualDetails);
            _formHelper.ClickElement(CourseDesc);
            _formHelper.ClickElement(EntryReqs);
            _formHelper.ClickElement(WhatYoullLearn);
            _formHelper.ClickElement(HowYoullLearn);
            _formHelper.ClickElement(EquipReqd);
            _formHelper.ClickElement(AssessMethod);
            _formHelper.ClickElement(NextSteps);
            _formHelper.ClickElement(Venue);
            _formHelper.ClickElement(OtherDatesandVenues);
        }
        public void VerifyCourseHeader()
        {
            _pageHelper.VerifyText(CourseHeader, _objectContext.Get("CourseHeader")).Should().BeTrue();
        }
        
    }    
}
