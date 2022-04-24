using AlfaSoftTest.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaSoftTest.Application.Facades
{
    public class BitbucketFacade
    {
        private const int DELAY_BETWEEN_REQUESTS = 5000;

        private readonly BitbucketApiClient _bitbucketApiClient;
        private readonly LoggingService _loggingService;

        public BitbucketFacade(LoggingService loggingService)
        {
            _loggingService = loggingService;
            _bitbucketApiClient = new BitbucketApiClient(_loggingService);
        }

        public async Task GetInformationForUsersAsync(IEnumerable<string> usersList)
        {
            foreach (var user in usersList)
            {
                _loggingService.LogInfo<BitbucketFacade>($"Getting information for user '{user}'");

                var result = await _bitbucketApiClient.GetUserAsync(user);
                if(result != null) _loggingService.LogInfo<BitbucketFacade>($"Success Result '{user}' = {result}");

                await Task.Delay(DELAY_BETWEEN_REQUESTS);
            }
        }
    }
}
