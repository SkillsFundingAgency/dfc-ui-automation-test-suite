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
        private readonly ObjectContext _objectContext;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By SearchPageHeader = By.CssSelector(".govuk-heading-xl");
        private By CourseSearchList = By.CssSelector(".govuk-heading-m");
        private By FilterButton = By.CssSelector("button.js-enabled");
        private By ErrorMsg = By.CssSelector(".govuk-body-s > p:nth-child(1)");
        private By Provider = By.Id("Provider");
        private By Location=By.Id("Location");
        private List<IWebElement> FiltersList => _pageHelper.FindElements(By.ClassName("govuk-radios__input"));


        #endregion
        public CourseSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
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
        public void SelectFilter(string filter)
        {
           if (!string.IsNullOrWhiteSpace(filter))
                {
                    var filteredText = filter.Replace(" ", string.Empty).ToUpper();
                    foreach (var button in FiltersList)
                    {
                    var buttonText = button.GetAttribute("value").Replace(" ", string.Empty).ToUpper();
                        if (buttonText.Contains(filteredText))
                        {
                            button.Click();
                        }
                    }
                }
            }
        public bool IsCourseFilterSelected(string filter)
        {
            var selected = false;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                var filteredText = filter.Replace(" ", string.Empty).ToUpper();
                foreach (var button in FiltersList)
                {
                    var buttonText = button.GetAttribute("value").Replace(" ", string.Empty).ToUpper();
                    if (buttonText.Contains(filteredText))
                    {
                        if (button.Selected == true)
                        {
                            selected = true;
                        }
                        else
                        {
                            selected = false;
                        }
                    }
                }
            }
            return selected;
        }
        
        public CourseDetailsPage ClickSelectedCourse()
        {            
            _formHelper.ClickElement(CourseSearchList);
            return new CourseDetailsPage(_context);
        }
        public void ValidateResults(string selectedCourseText)
        {
            
            _objectContext.Set("CourseHeader", _pageHelper.GetText(CourseSearchList));            
            _pageHelper.VerifyText(CourseSearchList, selectedCourseText);
            _objectContext.Set("CourseDetail", _pageHelper.GetText(CourseSearchList));
        }

        public CourseSearchPage ClickApplyFilter()
        {
            _formHelper.ClickElement(FilterButton);
            return this;
        }
        public void ValidateFilters(string prov, string location)
        {
            
            _pageHelper.VerifyValueAttributeOfAnElement(Provider, prov);
            _pageHelper.VerifyValueAttributeOfAnElement (Location, location);
        }
        public void  EnterLocation(string strLocation)
        {
            _formHelper.EnterText(Location, strLocation);           
        }

        public void EnterProvider(string strProv)
        {
            _formHelper.EnterText(Provider, strProv);            
        }

    }
}
