using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class Homepage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        private By JobCategoryList => By.CssSelector(".homepage-jobcategories li a");
        #endregion
        protected override string PageTitle => "";

        public Homepage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public JobCategoriesPage SelectJobCategory(string selectedCategory)
        {
            _formHelper.ClickElement(_pageHelper.SelectElementFromList(JobCategoryList, selectedCategory));
            return new JobCategoriesPage(_context);
        }
    }
}
