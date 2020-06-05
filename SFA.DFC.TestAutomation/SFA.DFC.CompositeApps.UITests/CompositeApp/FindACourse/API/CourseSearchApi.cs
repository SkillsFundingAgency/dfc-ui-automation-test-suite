﻿using RestSharp;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Models;
using SFA.DFC.CompositeApps.UITests.Config;
using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Utilities.RestApiFactory;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.API
{
    public class CourseSearchApi
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        private const string _resource = "/coursedirectory/findacourse/coursesearch";

        public CourseSearchApi(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();            
        }

        public async Task<IRestResponse<CourseSearchResponse>> ExecuteRequest()
        {
            var restClientFactory = new RestClientFactory(_context.GetFindACourseApiConfig<FindACourseApiConfig>().BaseUrl);
            var restRequestFactory = new RestRequestFactory(_resource, Method.POST);
            
            restRequestFactory.SetHeaders(new Dictionary<string, string>() { 
                { "Content-Type", "application/json-patch+json" }, 
                { "Ocp-Apim-Subscription-Key", "cb7cc988b0a646bea385c641221f67b4" } 
            });
            
            var requestBody = new CourseSearchBody() 
            {
                subjectKeyword = "a",
                limit = 20
            };
            
            restRequestFactory.AddBody(requestBody);
            var restApiHelper = new RestApiHelper(restClientFactory, restRequestFactory);

            return await restApiHelper.ExecuteAsync<CourseSearchResponse>();
        }
    }
}