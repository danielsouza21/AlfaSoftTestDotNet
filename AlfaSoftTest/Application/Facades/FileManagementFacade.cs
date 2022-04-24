using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlfaSoftTest.Application.Facades
{
    public static class FileManagementFacade
    {
        private const string FILE_INPUT_EXTENSION = ".txt";

        public static List<string> GetLinesFromTxtFile(string[] args)
        {
            //TODO: Extrair para facade de acesso a arquivos
            var filePath = args[0];
            if (!File.Exists(filePath)) throw new Exception($"File not exists {filePath}");

            var fileType = Path.GetExtension(filePath);
            if (fileType != FILE_INPUT_EXTENSION) throw new Exception($"File should be {FILE_INPUT_EXTENSION}");

            return File.ReadLines(filePath).ToList();
        }
    }
}
