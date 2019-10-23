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
    public class CourseResultsPage : BasePage
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
        public CourseResultsPage(ScenarioContext context) : base(context)
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
        public void VerifyErrorMessage(string errmsg)
        {
            _pageHelper.VerifyText(ErrorMsg, errmsg);
            //return this;
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
        public bool VerifyIsCourseFilterSelected(string filter)
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
        public CourseDetailsPage ClickSelectedCourse(int courseNo)
        {
            List<IWebElement> listOfCourses = _pageHelper.FindElements(CourseSearchList);
            _context.Add("CourseHeader", listOfCourses[courseNo - 1].Text);
            _formHelper.ClickElement(listOfCourses[courseNo-1]);
            return new CourseDetailsPage(_context);
        }
        public void VerifyResults()
        {
            string selectedCourseText = _objectContext.Get("CourseName");                   
            _pageHelper.VerifyText(CourseSearchList, selectedCourseText);
        }

        public CourseResultsPage ClickApplyFilter()
        {
            _formHelper.ClickElement(FilterButton);
            return this;
        }
        public void VerifyFilters()
        {
            
            _pageHelper.VerifyValueAttributeOfAnElement(Provider, _objectContext.Get("ProvName"));
            _pageHelper.VerifyValueAttributeOfAnElement (Location, _objectContext.Get("Location"));
        }
        public void  EnterLocation(string strLocation)
        {
            _objectContext.Replace("LocationName", strLocation);
            _formHelper.EnterText(Location, strLocation);           
        }

        public void EnterProvider(string strProv)
        {
            _objectContext.Replace("ProvName", strProv);
            _formHelper.EnterText(Provider, strProv);            
        }

    }
}
