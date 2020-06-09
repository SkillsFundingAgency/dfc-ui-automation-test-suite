using DFC.TestAutomation.UI.RestApiFactory;
using DFC.TestAutomation.UI.TestSupport;
using RestSharp;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Models;
using SFA.DFC.CompositeApps.UITests.Config;
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

        public async Task<IRestResponse<CourseSearchResponse>> SearchWithKeyword(string keyword)
        {
            var restClientFactory = new RestClientFactory(_context.GetFindACourseApiConfig<FindACourseApiConfig>().BaseUrl);
            var restRequestFactory = new RestRequestFactory(_resource, Method.POST);
            
            restRequestFactory.SetHeaders(new Dictionary<string, string>() { 
                { "Content-Type", "application/json-patch+json" }, 
                { "Ocp-Apim-Subscription-Key", _context.GetFindACourseApiConfig<FindACourseApiConfig>().OcpApimSubscriptionKey } 
            });
            
            var requestBody = new CourseSearchBody() 
            {
                subjectKeyword = keyword,
                limit = 20
            };
            
            restRequestFactory.AddBody(requestBody);
            var restApiHelper = new RestApiHelper(restClientFactory, restRequestFactory);

            return await restApiHelper.ExecuteAsync<CourseSearchResponse>();
        }
    }
}
