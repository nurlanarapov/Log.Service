namespace LogFilesProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _filesPath;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _filesPath = config["logFolderPath"];
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                string[] sourceFiles = Directory.GetFiles(_filesPath, "*.log");

                foreach (string sourceFile in sourceFiles)
                {
                    Processor.ProcessFile(sourceFile);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}