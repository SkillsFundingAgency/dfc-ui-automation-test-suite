using RestSharp;

namespace SFA.DFC.UI.Framework.Utilities.RestApiFactory
{
    public interface IRestRequestFactory
    {
        IRestRequest Create();
    }
}
