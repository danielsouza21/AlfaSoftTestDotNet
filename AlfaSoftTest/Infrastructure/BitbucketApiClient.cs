using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlfaSoftTest.Infrastructure
{
    public class BitbucketApiClient
    {
        private const string BITBUCKET_BASE_URL = "https://api.bitbucket.org/2.0";
        private const string BITBUCKET_USERS_ENDPOINT_PATH = "users";

        private readonly HttpClient _httpClient;

        public BitbucketApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BITBUCKET_BASE_URL);
            _httpClient.Timeout = TimeSpan.FromMinutes(1);
        }

        public async Task<string> GetUserAsync(string user)
        {
            var endpointFormat = "{0}/{1}";
            var requestUri = string.Format(endpointFormat, BITBUCKET_USERS_ENDPOINT_PATH, user);

            var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

            var responseContent = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                //app = JsonConvert.DeserializeObject<Application>(responseContent); => Deserialize new type

            }
            else
            {
                Console.WriteLine("Error getting Log");
            }

            return responseContent;
        }
    }
}
