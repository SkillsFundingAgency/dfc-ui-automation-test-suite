﻿using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FindACourseandVisitCourseDetailsPageSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
  

        private FACHomePage fACHomePage;
        private CourseSearchPage courseSearchPage;
        private CourseDetailsPage courseDetailsPage;

        public FindACourseandVisitCourseDetailsPageSteps(ScenarioContext context)
        {
            
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }
        [Given(@"I have navigated to Find a course page")]
        public void GivenIHaveNavigatedToFindACoursePage()
        {
            _webDriver.Url = _config.BaseUrl + "/find-a-course";
        }
        
        [Given(@"I have searched for a valid course '(.*)'")]
        public void GivenIHaveSearchedForAValidCourse(string strCourseName)
        {
            fACHomePage = new FACHomePage(_context).EnterSearchCriteria(strCourseName);
            _context.Add("CourseName", strCourseName);
            
        }
        
        [When(@"I click the Find a course button")]
        public void WhenIClickTheFindACourseButton()
        {
            fACHomePage = new FACHomePage(_context);
            fACHomePage.ClickFindACourse();
        }
        
       
        
        [When(@"I click the first course")]
        public void WhenIClickTheFirstCourse()
        {
            courseSearchPage.ClickSelectedCourse();
        }


        [Then(@"the results for the course should be listed")]
        public void ThenTheResultsForTheCourseShouldBeListed()
        {
            courseSearchPage = new CourseSearchPage(_context);
            _context.TryGetValue("CourseName", out string selectedCourseText);
            courseSearchPage.ValidateResults(selectedCourseText);
            

        }
        
        [Then(@"I should be taken to the course details page")]
        public void ThenIShouldBeTakenToTheCourseDetailsPage()
        {
            courseDetailsPage = new CourseDetailsPage(_context);
            

            
        }
        [Then(@"I should be able to validate the links")]
        public void ThenIShouldBeAbleToValidateTheLinks()
        {
            courseDetailsPage.ValidateLinks();
        }

    }
}
