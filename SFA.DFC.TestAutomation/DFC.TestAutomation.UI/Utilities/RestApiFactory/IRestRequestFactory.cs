using RestSharp;

namespace DFC.TestAutomation.UI.RestApiFactory
{
    public interface IRestRequestFactory
    {
        IRestRequest Create();
    }
}
