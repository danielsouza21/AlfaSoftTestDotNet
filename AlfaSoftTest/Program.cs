using AlfaSoftTest.Application.Facades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaSoftTest
{
    public class Program
    {
        //TODO: Deserialize response api
        //TODO: Log in output file 
        //TODO: Configure times between requests
        //TODO: Configure logout time

        private const int EXPECTED_COUNT_INPUT_ARGUMENTS = 1;

        public static void Main(string[] args)
        {
            MainAsync(args).Wait(); 
        }

        public async static Task MainAsync(string[] args)
        {
            if (args is null || args.Count() != EXPECTED_COUNT_INPUT_ARGUMENTS)
            {
                throw new Exception("Invalid entries. Correct execution must have a single argument with full path to a txt file.");
            }

            var linesFromTxtInput = FileManagementFacade.GetLinesFromTxtFile(args);

            var bitbucketApiClient = new BitbucketFacade();
            await bitbucketApiClient.ProcessUsersListAsync(linesFromTxtInput);
        }
    }
}
