﻿using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Pages
{
    public class CourseResultsPage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "Find a course";

        public CourseResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }
    }
}
