using AlfaSoftTest.Application.Facades;
using AlfaSoftTest.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaSoftTest
{
    public class Program
    {
        private const int EXPECTED_COUNT_INPUT_ARGUMENTS = 1;
        private const int DELAY_BEFORE_FINISH_APP = 5000;

        private const string OUTPUT_LOG_FILE_NAME = "OutputLog";

        public static void Main(string[] args)
        {
            MainAsync(args).Wait(); 
        }

        public async static Task MainAsync(string[] args)
        {
            var loggingService = new LoggingService(args, OUTPUT_LOG_FILE_NAME);            

            if (args is null || args.Count() != EXPECTED_COUNT_INPUT_ARGUMENTS)
            {
                var messageError = "Invalid entries. Correct execution must have a single argument with full path to a txt file.";
                loggingService.LogError(messageError);
                throw new Exception(messageError);
            }

            var linesFromTxtInput = FileManagementFacade.GetLinesFromTxtFile(args, loggingService);

            var bitbucketApiClient = new BitbucketFacade(loggingService);
            await bitbucketApiClient.GetInformationForUsersAsync(linesFromTxtInput);

            await Task.Delay(DELAY_BEFORE_FINISH_APP);
            loggingService.LogInfo<Program>("Application Finished");
        }
    }
}
