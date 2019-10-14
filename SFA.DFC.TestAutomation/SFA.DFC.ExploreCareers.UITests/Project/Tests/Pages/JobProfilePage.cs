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
            _context.Add("RelatedCareerSelected", _pageHelper.FindElements(RelatedCareersList)[relatedCareer-1].Text);
            IWebElement Profile = _pageHelper.FindElements(RelatedCareersList)[relatedCareer - 1];
            _formHelper.ClickElement(Profile);
            return this;
        }

        public void VerifyRelatedCareersSectionDisplayed()
        {
            _pageHelper.IsElementDisplayed(RelatedCareersSection);
        }

        public void VerifyNumberOfRelatedCareersDisplayed(int maxNoOfRelatedProfiles)
        {
            _pageHelper.GetCountOfElementsGroup(RelatedCareersList).Should().BeLessOrEqualTo(maxNoOfRelatedProfiles);
        }

    }
}
