using AlfaSoftTest.Application.Facades;
using AlfaSoftTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaSoftTest
{
    public class Program
    {
        private const int EXPECTED_COUNT_INPUT_ARGUMENTS = 1;

        public static void Main(string[] args)
        {
            if (args is null || args.Count() != EXPECTED_COUNT_INPUT_ARGUMENTS)
            {
                throw new Exception("Invalid entries. Correct execution must have a single argument with full path to a txt file.");
            }           

            var linesFromTxtInput = FileManagementFacade.GetLinesFromTxtFile(args);

            var bitbucketApiClient = new BitbucketApiClient();
            var response = await bitbucketApiClient.GetUserAsync(linesFromTxtInput.FirstOrDefault());
        }
    }
}
