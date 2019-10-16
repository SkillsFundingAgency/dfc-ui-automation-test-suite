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
    public class CourseSearchPage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By SearchPageHeader = By.CssSelector(".govuk-heading-xl");
        private By CourseSearchList = By.CssSelector(".govuk-heading-m");
        private By FilterButton = By.CssSelector("button.js-enabled");
        private By CourseHours = By.Name("CourseHours");
        private By CourseType = By.Name("CourseType");
        private By StartDate = By.Name("StartDate");
        private By ErrorMsg = By.CssSelector(".govuk-body-s > p:nth-child(1)");     
        

        #endregion
        public CourseSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            VerifyPageHeader();
        }
        public void VerifyPageHeader()
        {
            _pageHelper.VerifyText(SearchPageHeader, "Search");
        }

        public CourseSearchPage ValidateErrorMessage(string errmsg)
        {
            _pageHelper.VerifyText(ErrorMsg, errmsg);
            return this;
        }

        public CourseSearchPage SelectCourseType(string type)
        {
            _formHelper.SelectRadioButton(By.Id("CourseType_" + type.Replace(" ", "")));
            return this;
        }

        public CourseSearchPage SelectStartDate(string date)
        {
            _formHelper.SelectRadioButton(By.Id("StartDate_" + date.Replace(" ", "")));
            return this;
        }

        public CourseSearchPage SelectCourseHours(string hours)
        {

            _formHelper.SelectRadioButton(By.Id("CourseHours_" + hours.Replace(" ", "")));
            return this;
        }

        public CourseSearchPage ClickSelectedCourse()
        {
            _formHelper.ClickElement(CourseSearchList);
            _context.Add("CourseHeader", _pageHelper.GetText(CourseSearchList));           

            return this;
        }

        internal void ValidateResults(string selectedCourseText)
        {

            _pageHelper.VerifyText(CourseSearchList, selectedCourseText);
            
            
        }

        public CourseSearchPage ClickApplyFilter()
        {
            _formHelper.ClickElement(FilterButton);
            return this;
        }
        
    }
}
