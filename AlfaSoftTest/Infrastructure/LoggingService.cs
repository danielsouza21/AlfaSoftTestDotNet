using AlfaSoftTest.Application.Facades;
using System;
using System.IO;

namespace AlfaSoftTest.Infrastructure
{
    public class LoggingService
    {
        public LoggingService(string[] args, string outputLogFileName)
        {
            var fileFullPathFromArguments = FileManagementFacade.GetDirectoryNameFromPath(args);
            var fullFileName = $"{outputLogFileName}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

            var fileStream = new FileStream($"{fileFullPathFromArguments}/{fullFileName}", FileMode.Create);
            var streamWriter = new StreamWriter(fileStream);

            streamWriter.AutoFlush = true;
            Console.SetOut(streamWriter);
            Console.SetError(streamWriter);

            Console.WriteLine($"Running application AlfaSoftTest - {DateTime.Now}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] ==> ERROR: '{message}'");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] -> BitbucketApiClient: '{message}'");
        }
    }
}
