using AlfaSoftTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlfaSoftTest.Application.Facades
{
    public static class FileManagementFacade
    {
        private const string FILE_INPUT_EXTENSION = ".txt";

        public static List<string> GetLinesFromTxtFile(string[] args, LoggingService loggingService = null)
        {
            var filePath = CheckAndRetrieveFilePath(args, loggingService);

            var fileType = Path.GetExtension(filePath);
            if (fileType != FILE_INPUT_EXTENSION) 
            {
                var messageError = $"File should be {FILE_INPUT_EXTENSION}";
                if (loggingService != null) loggingService.LogError(messageError);
                throw new Exception(messageError);
            }

            return File.ReadLines(filePath).ToList();
        }

        private static string CheckAndRetrieveFilePath(string[] args, LoggingService loggingService = null)
        {
            var filePath = args[0];
            if (!File.Exists(filePath)) 
            {
                var messageError = $"File not exists {filePath}";
                if(loggingService != null) loggingService.LogError(messageError);
                throw new Exception($"File not exists {filePath}");
            }

            return filePath;
        }

        public static string GetDirectoryNameFromPath(string[] args, LoggingService loggingService = null)
        {
            var filePath = CheckAndRetrieveFilePath(args, loggingService);
            return Path.GetDirectoryName(filePath);
        }
    }
}
