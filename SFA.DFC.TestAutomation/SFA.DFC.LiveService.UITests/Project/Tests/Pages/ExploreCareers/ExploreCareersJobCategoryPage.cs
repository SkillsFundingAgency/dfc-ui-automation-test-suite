using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.LiveService.UITests.Project.Tests.Pages.ExploreCareers
{
    public class ExploreCareersJobCategoryPage : BasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "";

        public ExploreCareersJobCategoryPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}
