using LogFilesProcessor.Models;
using System.Text.Json;

namespace LogFilesProcessor
{
    public static class Processor
    {
        public static void ProcessFile(string sourceFile)
        {
            string partsDirectory = Path.GetDirectoryName(sourceFile) + "//parts";
            if (!Directory.Exists(partsDirectory))
                Directory.CreateDirectory(partsDirectory);

            string fileName = Path.GetFileNameWithoutExtension(sourceFile);
            string outputFilePrefix = $"{fileName}-";
            int fileRecords = 100;

            int partFileCount = Directory.GetFiles(partsDirectory, $"{fileName}-*.log").Length;
            int counter = partFileCount + 1;

            string outputFilePath = Path.Combine(partsDirectory, $"{outputFilePrefix}{counter:D4}.log");

            string json = string.Empty;
            using (StreamReader reader = new StreamReader(sourceFile))
            {
                string countData = reader.ReadLine();

                int countDataLst = int.Parse(countData);

                if((counter * fileRecords) < countDataLst)
                {
                    string jsonData = reader.ReadToEnd();

                    jsonData = $"[{jsonData}]";

                    var data = JsonSerializer.Deserialize<List<Data>>(jsonData);

                    var selectedData = data.Skip(partFileCount * fileRecords).Take(fileRecords);
                    json = JsonSerializer.Serialize(selectedData);
                }
            }

            if(!string.IsNullOrWhiteSpace(json))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath, true))
                {
                    writer.WriteLine(json);
                }
            }           
        }
    }
}