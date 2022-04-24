using AlfaSoftTest.Domain;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlfaSoftTest.Infrastructure
{
    public class BitbucketApiClient
    {
        private const string BITBUCKET_BASE_URL = "https://api.bitbucket.org";
        private const string BITBUCKET_VERSION_PATH = "2.0";
        private const string BITBUCKET_USERS_ENDPOINT_PATH = "users";

        private readonly HttpClient _httpClient;
        private readonly LoggingService _loggingService;

        public BitbucketApiClient(LoggingService loggingService)
        {
            _loggingService = loggingService;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BITBUCKET_BASE_URL);
            _httpClient.Timeout = TimeSpan.FromMinutes(1);
        }

        public async Task<UserBitbucket> GetUserAsync(string user)
        {
            var endpointFormat = "{0}/{1}/{2}";
            var requestUri = string.Format(endpointFormat, BITBUCKET_VERSION_PATH, BITBUCKET_USERS_ENDPOINT_PATH, user);

            var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

            var responseObject = new UserBitbucket();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                responseObject = JsonConvert.DeserializeObject<UserBitbucket>(responseContent);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _loggingService.LogInfo($"User '{user}' not found", nameof(BitbucketApiClient));
            }
            else
            {
                var messageError = $"Error getting for user '{user}'";
                _loggingService.LogError(messageError);
                throw new Exception(messageError);
            }

            return responseObject;
        }
    }
}
