using System.IO;

namespace Log.Service.Api.Logger
{
    public class FileLogger : ILogger
    {
        private bool disposed = false;

        private readonly string _logFolderPath;
        public FileLogger(IConfiguration configuration)
        {
            _logFolderPath = configuration["logFolderPath"];
        }

        public void Log(string Type, string message)
        {
            string filePath = Path.Combine(_logFolderPath, $"{Type}-{DateTime.Now.ToString("yyyy-MM-dd")}.log");
            int count = 0;

            if (System.IO.File.Exists(filePath))
            {
                var line = File.ReadLines(filePath).First();
                if (!string.IsNullOrWhiteSpace(line))
                    int.TryParse(line, out count);
            }

            count++;
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {              
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine($"{count:D6}");
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (count > 1)
                    writer.WriteLine($",{message}");
                else
                    writer.WriteLine(message);
            }
        }
    }
}