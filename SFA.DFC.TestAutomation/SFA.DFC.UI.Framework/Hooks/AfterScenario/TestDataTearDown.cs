﻿using CsvHelper;
using CsvHelper.Configuration.Attributes;
using NUnit.Framework;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class TestDataTearDown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public TestDataTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 10)]
        public void CollectTestData()
        {
            DateTime dateTime = DateTime.Now;

            string fileName = dateTime.ToString("HH-mm-ss")
                   + "_"
                   + _context.ScenarioInfo.Title
                   + ".txt";
            string directory = _objectContext.GetDirectory();

            string filePath = Path.Combine(directory, fileName);

            List<TestData> records = new List<TestData>();

            var testDatas = _objectContext.GetAll();

            testDatas.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testDatas[x.Key].ToString() }));

            using (var writer = new StreamWriter(filePath))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(records);
                    writer?.Flush();
                }
            }
            TestContext.AddTestAttachment(filePath, fileName);
        }
    }

    public class TestData
    {
        [Name("Key")]
        public string Key { get; set; }

        [Name("Value")]
        public string Value { get; set; }
    }
}
