﻿using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class ApprenticeshipDetailsPage : BasePage
    {
        private ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ObjectContext _objectContext;
        protected override string PageTitle => "";
        private By AppVacancyId => By.Id("vacancy-title");

        public ApprenticeshipDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public void VerifyCorrectApprenticeshipPage()
        {
             string AppSelected = _objectContext.Get("ApprenticeshipSelected");
            _pageHelper.VerifyText(AppVacancyId, AppSelected);
        }
    }
}