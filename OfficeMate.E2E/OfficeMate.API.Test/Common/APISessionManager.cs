using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using OfficeMate.API.Test.Configuration;

namespace OfficeMate.API.Test.Common
{
    public class APISessionManager : IDisposable
    {
        private HttpClient _httpClients;
        public HttpResponseMessage LatestResponseMessage { get; set; }

        public APISessionManager()
        {
            _httpClients = CreateHttpClient();
        }
        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(AuthorizationSettings.Audience);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public HttpClient GetSelectedClient()
        {
            return _httpClients;
        }
        public void Dispose()
        {
            _httpClients.Dispose();
        }
    }
}
