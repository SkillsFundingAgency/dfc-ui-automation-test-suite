using RestSharp;

namespace DFC.TestAutomation.UI.RestApiFactory
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
