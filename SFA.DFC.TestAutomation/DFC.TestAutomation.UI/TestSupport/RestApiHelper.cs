using RestSharp;
using SFA.DFC.UI.Framework.Utilities.RestApiFactory;
using System.Threading.Tasks;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public class RestApiHelper
    {
        private IRestClientFactory RestClientFactory { get; set; }
        private IRestRequestFactory RestRequestFactory { get; set; }

        public RestApiHelper(IRestClientFactory restClientFactory, IRestRequestFactory restRequestFactory)
        {
            this.RestClientFactory = restClientFactory;
            this.RestRequestFactory = restRequestFactory;
        }

        public async Task<IRestResponse<T>> ExecuteAsync<T>()
        {
            return await this.RestClientFactory.Create().ExecuteAsync<T>(this.RestRequestFactory.Create());
        }
    }
}
