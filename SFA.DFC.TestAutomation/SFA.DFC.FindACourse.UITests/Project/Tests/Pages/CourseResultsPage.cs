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
        private By CourseSearchList = By.CssSelector(".govuk-heading-m .govuk-link");
        private By FilterButton = By.CssSelector("button.js-enabled");
        private By ErrorMsg = By.CssSelector(".govuk-body-s .govuk-body");
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
            
        }
        public void VerifyPageHeader()
        {
            _pageHelper.VerifyText(SearchPageHeader, "Search").Should().BeTrue();
        }
        public void VerifyErrorMessage()
        {
            var errmsg = "We didn't find any results for '" + _objectContext.Get("CourseName") + "' with the active filters you've applied. Try searching again.";
            _pageHelper.VerifyText(ErrorMsg, errmsg).Should().BeTrue();
            
        }
        public void SelectFilter(string filter)
        {
            try
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
                            button.Selected.Should().BeTrue();
                        }

                    }
                }
            }
            catch
            {
                throw new Exception(filter + "not found");
            }
        }
        public void VerifyIsCourseFilterSelected(string filter)
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
            selected.Should().BeTrue();
            
        }        
        public CourseDetailsPage ClickSelectedCourse(int courseNo)
        {
            var listOfCourses = _pageHelper.FindElements(CourseSearchList);
            _objectContext.Set("CourseHeader", _pageHelper.GetText(listOfCourses[courseNo - 1]));
            _formHelper.ClickElement(listOfCourses[courseNo-1]);
            return new CourseDetailsPage(_context);
        }
        public void VerifyResults()
        {
            _pageHelper.GetCountOfElementsGroup(CourseSearchList)
                .Should().BeGreaterThan(0);
        }

        public CourseResultsPage ClickApplyFilter()
        {
            _formHelper.ClickElement(FilterButton);
            return this;
        }
        public void VerifyFilters()
        {

            _pageHelper.VerifyValueAttributeOfAnElement(Provider, _objectContext.Get("ProvName"));
            _pageHelper.VerifyValueAttributeOfAnElement (Location, _objectContext.Get("LocationName"));
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
