using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobProfilePage : BasePage
    {
        #region Helpers and Context
        private ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        private FormCompletionHelper _formHelper;
        #endregion

        #region Page Attributes
        protected override string PageTitle => "";
        private string JobProfileSelected;
        private string RelatedCareerSelected;
        private By RelatedCareersSection => By.ClassName("job-profile-related");
        private By RelatedCareersList => By.CssSelector(".list-big li");
        private By CourseSection => By.CssSelector(".dfc-code-jp-trainingCourse .opportunity-item");
        private By ListOfCourses => By.CssSelector(".dfc-code-jp-trainingCourse .opportunity-item .heading-small a");
        private By CoursesNearYouLink => By.CssSelector(".dfc-code-jp-TrainingCoursesText a");
        private By ApprenticeshipSection => By.CssSelector("#appGeneric .opportunity-item");
        private By ListOfApprenticeships => By.CssSelector("#appGeneric .opportunity-item .heading-small a");
        private By ApprenticeshipNotDisplayedText => By.ClassName("dfc-code-jp-novacancyText");
        private By JPFeedbackYes => By.ClassName("yes");
        private By JPFeedbackNo => By.ClassName("no");
        private By JPFeedbackThankYouText => By.ClassName("job-profile-feedback-end-yes");
        private By JPFeedbackAdditionalSurveyText => By.ClassName("job-profile-feedback-end-no");
        private By JPAdditionalFeedbackSurvey => By.Id("job-profile-feedback-survey");

        #region JobProfile Segments
        private By JobProfileHeroContainer => By.Id("MainContentTop_T41A29498007_Col00");
        private By JobProfileAnchorLinks => By.ClassName("job-profile-anchorlinks");
        private By JobProfileHowToBecome => By.Id("HowToBecome");
        private By JobProfileSkills => By.Id("Skills");
        private By JobProfileWhatYouWillDo => By.Id("WhatYouWillDo");
        private By JobProfileCareerPath => By.Id("CareerPathAndProgression");
        private By JobProfileCurrentOpportunities => By.Id("current-opportunities");
        private By JobProfileFeedbackSurvey => By.ClassName("job-profile-feedback");


        #endregion

        #endregion


        public JobProfilePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public void VerifyCorrectJobProfilePage()
        {
            _context.TryGetValue("JCProfileSelected", out JobProfileSelected);
            _context.TryGetValue("RelatedCareerSelected", out RelatedCareerSelected);
            if (!string.IsNullOrEmpty(JobProfileSelected))
            {
                _pageHelper.VerifyText(PageHeader, JobProfileSelected);
            }
            else
            {
                _pageHelper.VerifyText(PageHeader, RelatedCareerSelected);
            }
        }

        public JobProfilePage SelectRelatedCareer(int relatedCareer)
        {
            int careerIndex = relatedCareer - 1;
            AddElementTextToContext("RelatedCareerSelected", RelatedCareersList, careerIndex);
            _formHelper.ClickElement(_pageHelper.FindElements(RelatedCareersList)[careerIndex]);
            return this;
        }

        public CourseDetailsPage SelectCourse(int courseToSelect)
        {
            int courseIndex = courseToSelect - 1;
            AddElementTextToContext("CourseSelected", ListOfCourses, courseIndex);
            _formHelper.ClickElement(_pageHelper.FindElements(ListOfCourses)[courseIndex]);
            return new CourseDetailsPage(_context);
        }

        public FindACourseHomePage SelectFindCoursesNearYouLink()
        {
            _formHelper.ClickElement(CoursesNearYouLink);
            return new FindACourseHomePage(_context);
        }

        public ApprenticeshipDetailsPage SelectApprenticeship(int appToSelect)
        {
            int appIndex = appToSelect - 1;
            AddElementTextToContext("ApprenticeshipSelected", ListOfApprenticeships, appIndex);
            _formHelper.ClickElement(_pageHelper.FindElements(ListOfApprenticeships)[appIndex]);
            return new ApprenticeshipDetailsPage(_context);
        }

        public void VerifyRelatedCareersSectionDisplayed()
        {
            _pageHelper.IsElementDisplayed(RelatedCareersSection);
        }

        public void VerifyNumberOfRelatedCareersDisplayed(int maxNoOfRelatedProfiles)
        {
            _pageHelper.GetCountOfElementsGroup(RelatedCareersList).Should().BeLessOrEqualTo(maxNoOfRelatedProfiles);
        }

        public void VerifyCoursesAreDisplayed()
        {
            _pageHelper.IsElementDisplayed(CourseSection);
        }

        public void VerifyApprenticeAreDisplayed()
        {
            _pageHelper.IsElementDisplayed(ApprenticeshipSection);
        }

        public void AddElementTextToContext(string contextKey, By listOfElements, int elementIndex)
        {
            _context.Add(contextKey, _pageHelper.FindElements(listOfElements)[elementIndex].Text);
        }

        public void VerifyAllProfileSegments()
        {
            _pageHelper.IsElementDisplayed(JobProfileHeroContainer);
            _pageHelper.IsElementDisplayed(JobProfileAnchorLinks);
            _pageHelper.IsElementDisplayed(JobProfileHowToBecome);
            _pageHelper.IsElementDisplayed(JobProfileWhatYouWillDo);
            _pageHelper.IsElementDisplayed(JobProfileSkills);
            _pageHelper.IsElementDisplayed(JobProfileCareerPath);
            _pageHelper.IsElementDisplayed(JobProfileCurrentOpportunities);
            _pageHelper.IsElementDisplayed(JobProfileFeedbackSurvey);
        }

        public void VerifyNoApprenticeshipsDisplayed()
        {
            _pageHelper.IsElementDisplayed(ApprenticeshipNotDisplayedText);
            _pageHelper.VerifyText(ApprenticeshipNotDisplayedText, "We can't find any apprenticeship vacancies in England");
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
            _pageHelper.IsElementDisplayed(JPFeedbackThankYouText);
        }

        public void VerifyAdditionalSurveyMessage()
        {
            _pageHelper.IsElementDisplayed(JPFeedbackAdditionalSurveyText);
        }
        public void ClickTakeAdditionalSurveyLink()
        {
            _formHelper.ClickElement(JPAdditionalFeedbackSurvey);
        }

        #region SurveyMonkeyScreens     
        private By QuestionTitle => By.ClassName("ss-question-title");
        private By Submit => By.Id("cmdGo");
        private By TextInput => By.ClassName("ss-input-textarea");
        public void VerifySurveyMonkeyScreen()
        {
            _pageHelper.IsElementDisplayed(QuestionTitle);
        }

        public JobProfileFeedbackThankYouPage EnterFeedback(string feedback)
        {
            _formHelper.EnterText(TextInput, feedback);
            _formHelper.ClickElement(Submit);
            return new JobProfileFeedbackThankYouPage(_context);
        }
        #endregion
    }
}
