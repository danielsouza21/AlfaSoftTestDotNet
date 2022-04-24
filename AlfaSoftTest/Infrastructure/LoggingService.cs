using AlfaSoftTest.Application.Facades;
using System;
using System.IO;

namespace AlfaSoftTest.Infrastructure
{
    public class LoggingService
    {
        private readonly StreamWriter _streamWriter;

        public LoggingService(string[] args, string outputLogFileName)
        {
            var fileFullPathFromArguments = FileManagementFacade.GetDirectoryNameFromPath(args);
            var fullFileName = $"{outputLogFileName}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

            var fileStream = new FileStream($"{fileFullPathFromArguments}/{fullFileName}", FileMode.Create);
            _streamWriter = new StreamWriter(fileStream);

            _streamWriter.AutoFlush = true;

            var startMessage = $"Running application AlfaSoftTest - {DateTime.Now}";
            LogInfo<LoggingService>(startMessage);
        }

        public void LogError(string message)
        {
            var messageFormatted = $"[{DateTime.Now}] ==> ERROR: '{message}'";
            _streamWriter.WriteLine(messageFormatted);
            Console.WriteLine(messageFormatted);
        }

        public void LogInfo<Service>(string message)
        {
            var messageFormatted = $"[{DateTime.Now}] -> {typeof(Service).Name}: '{message}'";
            _streamWriter.WriteLine(messageFormatted);
            Console.WriteLine(messageFormatted);
        }
    }
}
