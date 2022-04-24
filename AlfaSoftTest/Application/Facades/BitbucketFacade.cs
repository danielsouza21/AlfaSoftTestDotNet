using AlfaSoftTest.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaSoftTest.Application.Facades
{
    public class BitbucketFacade
    {
        private readonly BitbucketApiClient _bitbucketApiClient;

        public BitbucketFacade()
        {
            _bitbucketApiClient = new BitbucketApiClient();
        }

        public async Task ProcessUsersListAsync(IEnumerable<string> usersList) //TODO: Trocar nome metodo
        {
            foreach (var user in usersList)
            {
                var result = await _bitbucketApiClient.GetUserAsync(user);
            }
        }
    }
}
