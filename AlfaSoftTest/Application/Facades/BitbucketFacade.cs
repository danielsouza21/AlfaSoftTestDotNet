using AlfaSoftTest.Infrastructure;
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

        public async Task ProcessUsersListAsync() //TODO: Trocar nome
        {

        }
    }
}
