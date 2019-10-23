using OpenQA.Selenium;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string ExploreCareersConfigKey = "explorecareersconfig";
        private const string FindACourseConfigKey = "findacourseconfig";
        private const string MongoDbConfigKey = "mongodbconfig";
        private const string WebDriverKey = "webdriver";
        #endregion

        public static void SetExploreCareersConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ExploreCareersConfigKey);
        }

        public static void SetFindACourseConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, FindACourseConfigKey);
        }

        public static T GetExploreCareersConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ExploreCareersConfigKey);
        }

        public static T GetFindACourseConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, FindACourseConfigKey);
        }

        public static void SetMongoDbConfig(this ScenarioContext context, MongoDbConfig value)
        {
            Set(context, value, MongoDbConfigKey);
        }

        public static MongoDbConfig GetMongoDbConfig(this ScenarioContext context)
        {
            return Get<MongoDbConfig>(context, MongoDbConfigKey);
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            Set(context, webDriver, WebDriverKey);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return Get<IWebDriver>(context, WebDriverKey);
        }

        private static void Set<T>(ScenarioContext context, T value, string key)
        {
            context.Set(value, key);
        }

        public static T Get<T>(ScenarioContext context, string key)
        {
            return context.Get<T>(key);
        }
    }
}
