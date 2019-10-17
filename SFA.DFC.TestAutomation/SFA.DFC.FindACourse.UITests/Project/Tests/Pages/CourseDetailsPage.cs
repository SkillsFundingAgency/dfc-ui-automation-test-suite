using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.Pages
{
    public class CourseDetailsPage : BasePage
    {
        protected override string PageTitle => "";
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion
        #region Page Elements
        private By CourseHeader = By.CssSelector(".govuk-heading-l");
        private By QualDetails = By.LinkText("Qualification details");
        private By CourseDesc = By.LinkText("Course description");
        private By EntryReqs = By.LinkText("Entry requirements");
        private By EquipReqd = By.LinkText("Equipment required");
        private By AssessMethod = By.LinkText("Assessment method");
        private By Venue = By.LinkText("Venue");
        private By OtherDatesandVenues = By.LinkText("Other dates and venues");
        #endregion
        public CourseDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();           
        }
        public void  ValidateLinks()
        {
            _pageHelper.VerifyText(QualDetails, "Qualification details");
            _pageHelper.VerifyText(CourseDesc , "Course description");
            _pageHelper.VerifyText(EntryReqs , "Entry requirements");
            _pageHelper.VerifyText(EquipReqd , "Equipment required");
            _pageHelper.VerifyText(AssessMethod , "Assessment method");
            _pageHelper.VerifyText(Venue , "Venue");
            _pageHelper.VerifyText(OtherDatesandVenues , "Other dates and venues");            
        }
        public void ClickLinks()
        {
            _formHelper.ClickElement(QualDetails);
            _formHelper.ClickElement(CourseDesc);
            _formHelper.ClickElement(EntryReqs);
            _formHelper.ClickElement(EquipReqd);
            _formHelper.ClickElement(AssessMethod);
            _formHelper.ClickElement(Venue);
            _formHelper.ClickElement(OtherDatesandVenues);
        }
        public void VerifyCourseHeader(string courseHeader)
        {
            _pageHelper.VerifyText(CourseHeader, courseHeader);
        }
        
    }    
}
