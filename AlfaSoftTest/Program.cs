using System;
using System.IO;
using System.Linq;

namespace AlfaSoftTest
{
    public static class Program
    {
        private const string FILE_INPUT_EXTENSION = ".txt";

        static void Main(string[] args)
        {
            //TODO: Extrair para método e facade
            if (args is null || args.Count() != 1) throw new Exception("Invalid entries. Correct execution must have a single argument with full path to a txt file.");

            var filePath = args[0];
            if(!File.Exists(filePath)) throw new Exception($"File not exists {filePath}");

            var fileType = Path.GetExtension(filePath);
            if (fileType != FILE_INPUT_EXTENSION) throw new Exception($"File should be {FILE_INPUT_EXTENSION}");

            var lines = File.ReadLines(filePath).ToList();
            lines.ForEach(x => Console.WriteLine(x));
        }
    }
}
