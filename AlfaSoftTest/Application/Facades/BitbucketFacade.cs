using AlfaSoftTest.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaSoftTest.Application.Facades
{
    public class BitbucketFacade
    {
        private readonly BitbucketApiClient _bitbucketApiClient;
        private readonly LoggingService _loggingService;

        public BitbucketFacade(LoggingService loggingService)
        {
            _loggingService = loggingService;
            _bitbucketApiClient = new BitbucketApiClient(_loggingService);
        }

        public async Task ProcessUsersListAsync(IEnumerable<string> usersList) //TODO: Trocar nome metodo
        {
            foreach (var user in usersList)
            {
                var result = await _bitbucketApiClient.GetUserAsync(user);
                await Task.Delay(DELAY_BEFORE_FINISH_APP);
            }
        }
    }
}
