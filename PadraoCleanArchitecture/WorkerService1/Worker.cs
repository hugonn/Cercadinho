using DataReader.Core.Ports;

namespace DataWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFilePort _filePort;
        private string _environment;

        public Worker(
            ILogger<Worker> logger, 
            IFilePort filePort
        )
        {
            _logger = logger;
            _filePort = filePort;
            _environment = Environment.GetEnvironmentVariable("HOME_PATH");
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var watcher = new FileSystemWatcher(@$"{_environment}\in");

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Created += OnCreated;

            watcher.Filter = "*.DAT";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            var fileName = e.Name.Split(".");
            _filePort.Process(_environment, fileName[0]);
        }
    }
}