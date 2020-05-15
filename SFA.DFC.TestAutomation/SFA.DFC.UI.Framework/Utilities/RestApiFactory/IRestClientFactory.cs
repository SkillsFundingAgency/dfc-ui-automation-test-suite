using RestSharp;

namespace SFA.DFC.UI.Framework.Utilities.RestApiFactory
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
