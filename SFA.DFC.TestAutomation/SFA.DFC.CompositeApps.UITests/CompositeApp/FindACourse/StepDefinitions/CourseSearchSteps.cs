using DFC.TestAutomation.UI.TestSupport;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Models;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Pages;
using SFA.DFC.CompositeApps.UITests.Config;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.StepDefinitions
{
    [Binding]
    public class CourseSearchSteps
    {
        private readonly ScenarioContext _context;
        private CourseSearchPage courseSearchPage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;

        public CourseSearchSteps(ScenarioContext context)
        {
            _context = context;
            courseSearchPage = new CourseSearchPage(context);
            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string searchTerm)
        {
            courseSearchPage.EnterKeywordIntoTheKeywordSearchBox(searchTerm);
            courseSearchPage.ClickKeywordSearchButton();
        }

        [Given(@"I am on the find a course page")]
        public void GivenIAmOnTheFindACoursePage()
        {
            _webDriver.Url = _config.BaseUrl + "/find-a-course";
            courseSearchPage.VerifyPage();
        }

        [Then(@"I am presented with a no results message")]
        public void ThenIAmPresentedWithANoResultsMessage()
        {
            Assert.IsTrue(courseSearchPage.IsNoResultsMessageDisplayed());
        }

        [Then(@"I am presented with search results")]
        public void ThenIAmPresentedWithSearchResults()
        {
            Assert.IsTrue(courseSearchPage.AreOneOrMoreResultsDisplayed());
        }

        [Then(@"the showing courses label displays the correct number of results")]
        public void ThenTheShowingCoursesLabelDisplaysTheCorrectNumberOfResults()
        {
            var previouslyRecordedTotal = _objectContext.Get<int>("TotalResults").ToString();
            var label = courseSearchPage.GetTotalResultsLabel();
            var regex = new Regex(" |[A-z,]");
            var displayedTotal = regex.Replace(label, string.Empty);
            Assert.AreEqual(previouslyRecordedTotal, displayedTotal);
        }

        [Given(@"I search for a course with a start date")]
        public void GivenISearchForACourseWithAStartDate()
        {
            GivenISearchFor($"\"{_objectContext.Get<Results>("SearchResultWithStartDate").courseName}\"");
        }

        [Then(@"the course start date is displayed correctly")]
        public void ThenTheCourseStartDateIsDisplayedCorrectly()
        {
            var result = courseSearchPage.GetResults().Where(r => r.courseName.Equals(_objectContext.Get<Results>("SearchResultWithStartDate").courseName)).FirstOrDefault();
            Assert.IsNotNull(result, $"Unable to find the course with name: {_objectContext.Get<Results>("SearchResultWithStartDate").courseName}");
            Assert.AreEqual(_objectContext.Get<Results>("SearchResultWithStartDate").startDate, result.startDate);
        }
    }
}
