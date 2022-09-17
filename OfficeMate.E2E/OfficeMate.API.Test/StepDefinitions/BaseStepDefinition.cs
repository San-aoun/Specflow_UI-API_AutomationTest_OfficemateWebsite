using System.Text;

using Newtonsoft.Json;

using OfficeMate.API.Test.Common;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OfficeMate.API.Test.StepDefinitions
{
    public class BaseStepDefinition
    {
        protected readonly FeatureContext _featureContext;
        protected HttpClient _apiClients;
        protected readonly APISessionManager _apiSessionManager;

        public BaseStepDefinition(FeatureContext featureContext)
        {
            _featureContext = featureContext;

            _apiSessionManager = featureContext.FeatureContainer.Resolve<APISessionManager>();
            _apiClients = _apiSessionManager.GetSelectedClient();
        }

        protected HttpResponseMessage LatestResponseMessage => _apiSessionManager.LatestResponseMessage;
        protected Uri HttpClientBaseAddress => _apiClients.BaseAddress;

        public async Task RequestAsync(HttpMethod httpMethod, string apiEndpoint, string content = null)
        {
            var url = $"{HttpClientBaseAddress}{apiEndpoint}";
            HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, url);

            if (content != null)
            {
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            await SendAsync(requestMessage);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            var httpResponseMessage = await _apiClients.SendAsync(requestMessage);
            _apiSessionManager.LatestResponseMessage = httpResponseMessage;

            return _apiSessionManager.LatestResponseMessage;
        }

        #region DeserializeResponse

        protected async Task AssertInstanceFromResponseWithTable<T>(Table table)
        {
            var responseContent = await LatestResponseMessage.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(responseContent);

            table.CompareToInstance(content);
        }
        #endregion

    }
}
