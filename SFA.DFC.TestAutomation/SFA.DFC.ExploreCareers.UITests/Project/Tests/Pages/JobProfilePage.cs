﻿using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobProfilePage : BasePage
    {
        #region Helpers
        private ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        private FormCompletionHelper _formHelper;
        private readonly ObjectContext _objectContext;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private By RelatedCareersSection => By.ClassName("job-profile-related");
        private By RelatedCareersList => By.CssSelector(".list-big li");
        private By CourseSection => By.CssSelector(".dfc-code-jp-trainingCourse .opportunity-item");
        private By ListOfCourses => By.CssSelector(".dfc-code-jp-trainingCourse .opportunity-item .govuk-heading-s a");
        private By CoursesNearYouLink => By.PartialLinkText("courses near you");
        private By ApprenticeshipSection => By.Id("appGeneric");
        private By ApprenticeshipContainer => By.CssSelector("#appGeneric .opportunity-item");
        private By ListOfApprenticeships => By.CssSelector("#appGeneric .opportunity-item .govuk-heading-s a");
        private By ApprenticeshipNotDisplayedText => By.ClassName("dfc-code-jp-novacancyText");
        private By JPFeedbackYes => By.ClassName("yes");
        private By JPFeedbackNo => By.ClassName("no");
        private By JPFeedbackThankYouText => By.ClassName("job-profile-feedback-end-yes");
        private By JPFeedbackAdditionalSurveyText => By.ClassName("job-profile-feedback-end-no");
        private By JPAdditionalFeedbackSurvey => By.Id("job-profile-feedback-survey");
        private By JPSearchField => By.ClassName("search-input");
        private By SubmitJPSearch => By.ClassName("submit");
        private By HomeBreadcrumbLink => By.ClassName("govuk-breadcrumbs__link");
        private By Alert404PageTitle => By.ClassName("heading-xlarge");
        protected override By PageHeader => By.CssSelector(".job-profile-hero h1");

        #region JobProfile Segments
        private By JobProfileHeroContainer => By.ClassName("job-profile-hero");
        private By JobProfileAnchorLinks => By.ClassName("jump-links");
        private By JobProfileHowToBecome => By.Id("job-profile-accordion-with-summary-sections-heading-1");
        private By JobProfileSkills => By.Id("job-profile-accordion-with-summary-sections-heading-2");
        private By JobProfileWhatYouWillDo => By.Id("job-profile-accordion-with-summary-sections-heading-3");
        private By JobProfileCareerPath => By.Id("job-profile-accordion-with-summary-sections-heading-4");
        private By JobProfileCurrentOpportunities => By.Id("job-profile-accordion-with-summary-sections-heading-5");
        private By JobProfileFeedbackSurvey => By.ClassName("job-profile-feedback");


        #endregion

        #endregion


        public JobProfilePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public void VerifyCorrectJobProfilePage()
        {
            string JobCategoryProfileSelected = _objectContext.Get("JCProfileSelected");
            string RelatedCareerSelected = _objectContext.Get("RelatedCareerSelected");
            string SearchJobProfileSelected = _objectContext.Get("JPSearchResultSelected");

            if (!string.IsNullOrEmpty(JobCategoryProfileSelected))
            {
                _pageHelper.VerifyText(PageHeader, JobCategoryProfileSelected).Should().BeTrue();
            }
            else if (!string.IsNullOrEmpty(RelatedCareerSelected))
            {
                _pageHelper.VerifyText(PageHeader, RelatedCareerSelected).Should().BeTrue();
            }
            else
            {
                _pageHelper.VerifyText(PageHeader, SearchJobProfileSelected).Should().BeTrue();
            }
        }

        public JobProfilePage ClickRelatedCareer(int relatedCareer)
        {
            int careerIndex = relatedCareer - 1;
            AddElementTextToContext("RelatedCareerSelected", RelatedCareersList, careerIndex);
            _formHelper.ClickElement(_pageHelper.FindElements(RelatedCareersList)[careerIndex]);
            return this;
        }

        public CourseDetailsPage ClickCourse(int courseToSelect)
        {
            int courseIndex = courseToSelect - 1;
            AddElementTextToContext("CourseSelected", ListOfCourses, courseIndex);
            _formHelper.ClickElement(_pageHelper.FindElements(ListOfCourses)[courseIndex]);
            return new CourseDetailsPage(_context);
        }

        public FindACourseHomePage ClickFindCoursesNearYouLink()
        {
            _formHelper.ClickElement(JobProfileCurrentOpportunities);
            _formHelper.ClickElement(CoursesNearYouLink);
            return new FindACourseHomePage(_context);
        }

        public ApprenticeshipDetailsPage ClickApprenticeship(int appToSelect)
        {
            int appIndex = appToSelect - 1;
            int apprenticeshipsCount = _pageHelper.GetCountOfElementsGroup(ApprenticeshipContainer);
            
            if(apprenticeshipsCount.Equals(0))
            {
                throw new NoSuchElementException($"Unable to click the apprenticeship at index {appToSelect} as there are no apprenticeships displayed for this job profile.");
            }

            AddElementTextToContext("ApprenticeshipSelected", ListOfApprenticeships, appIndex);
            _formHelper.ClickElement(_pageHelper.FindElements(ListOfApprenticeships)[appIndex]);
            return new ApprenticeshipDetailsPage(_context);
        }

        public void VerifyRelatedCareersSectionDisplayed()
        {
            _pageHelper.IsElementDisplayed(RelatedCareersSection).Should().BeTrue();
        }

        public void VerifyNumberOfRelatedCareersDisplayed(int maxNoOfRelatedProfiles)
        {
            _pageHelper.GetCountOfElementsGroup(RelatedCareersList).Should().BeLessOrEqualTo(maxNoOfRelatedProfiles);
        }

        public void VerifyCoursesAreDisplayed()
        {
            _formHelper.ClickElement(JobProfileCurrentOpportunities);
            _pageHelper.IsElementDisplayed(CourseSection).Should().BeTrue();
        }

        public void VerifyApprenticeAreDisplayed()
        {
            _formHelper.ClickElement(JobProfileCurrentOpportunities);
            _pageHelper.IsElementDisplayed(ApprenticeshipSection).Should().BeTrue();
        }

        public void AddElementTextToContext(string contextKey, By listOfElements, int elementIndex)
        {
            _objectContext.Set(contextKey, _pageHelper.GetText(_pageHelper.FindElements(listOfElements)[elementIndex]));
        }

        public void VerifyAllProfileSegments()
        {
            _pageHelper.IsElementDisplayed(JobProfileHeroContainer).Should().BeTrue();
            _pageHelper.IsElementDisplayed(JobProfileHowToBecome).Should().BeTrue();
            _pageHelper.IsElementDisplayed(JobProfileWhatYouWillDo).Should().BeTrue();
            _pageHelper.IsElementDisplayed(JobProfileSkills).Should().BeTrue();
            _pageHelper.IsElementDisplayed(JobProfileCareerPath).Should().BeTrue();
            _pageHelper.IsElementDisplayed(JobProfileCurrentOpportunities).Should().BeTrue();
            _pageHelper.IsElementDisplayed(JobProfileFeedbackSurvey).Should().BeTrue();
        }

        public void VerifyNoApprenticeshipsDisplayed()
        {
            _formHelper.ClickElement(JobProfileCurrentOpportunities);
            _pageHelper.IsElementDisplayed(ApprenticeshipNotDisplayedText).Should().BeTrue();
            _pageHelper.VerifyText(ApprenticeshipNotDisplayedText, "We can't find any apprenticeship vacancies in England").Should().BeTrue();
        }

        public void ClickYesOnFeedbackBanner()
        {
            _formHelper.ClickElement(JPFeedbackYes);
        }

        public void ClickNoOnFeedbackBanner()
        {
            _formHelper.ClickElement(JPFeedbackNo);
        }

        public void VerifyJPFeedbackThankYouMessage()
        {
            _pageHelper.IsElementDisplayed(JPFeedbackThankYouText).Should().BeTrue();
        }

        public void VerifyAdditionalSurveyMessage()
        {
            _pageHelper.IsElementDisplayed(JPFeedbackAdditionalSurveyText).Should().BeTrue();
        }
        public void ClickTakeAdditionalSurveyLink()
        {
            _formHelper.ClickElement(JPAdditionalFeedbackSurvey);
        }

        public SearchResultsPage SearchOnJobProfile(string searchTerm)
        {
            _objectContext.Set("JPSearchTerm", searchTerm);
            _formHelper.EnterText(JPSearchField, searchTerm);
            _formHelper.ClickElement(SubmitJPSearch);
            return new SearchResultsPage(_context);
        }

        public void Verify404Page()
        {
            _pageHelper.IsElementDisplayed(Alert404PageTitle).Should().BeTrue();
            _pageHelper.GetText(Alert404PageTitle).Should().Contain("Page not found");
        }

        #region SurveyMonkeyScreens     
        private By QuestionTitle => By.ClassName("ss-question-title");
        private By SubmitJPFeedbackSurvey => By.Id("cmdGo");
        private By TextInput => By.ClassName("ss-input-textarea");
        public void VerifySurveyMonkeyScreen()
        {
            _pageHelper.IsElementDisplayed(QuestionTitle).Should().BeTrue();
        }

        public JobProfileFeedbackThankYouPage EnterFeedback(string feedback)
        {
            _formHelper.EnterText(TextInput, feedback);
            _formHelper.ClickElement(SubmitJPFeedbackSurvey);
            return new JobProfileFeedbackThankYouPage(_context);
        }

        public Homepage ClickHomeBreadcrumb()
        {
            _formHelper.ClickElement(HomeBreadcrumbLink);
            return new Homepage(_context);
        }
        #endregion
    }
}
