using System.Net.Http.Headers;
using System.Text;

using Newtonsoft.Json;

using OfficeMate.E2E.Configuration;

namespace OfficeMate.E2E.Common
{
    public class APISessionManager
    {
        private readonly HttpClient _httpClient;

        public APISessionManager(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException($"'{nameof(token)}' cannot be null or whitespace", nameof(token));

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task PostRequestAsync(object body)
        {
            var uri = new Uri($"{Settings.WebUrl}/api/v1/emails");

            var json = JsonConvert.SerializeObject(body);
            var dataBody = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(uri, dataBody);
            Console.WriteLine(httpResponseMessage.StatusCode);
        }

    }
}
