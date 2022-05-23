
void Main()
{
    using var watcher = new FileSystemWatcher(@$"{Environment.GetEnvironmentVariable("HOME_PATH")}\in");

    watcher.NotifyFilter = NotifyFilters.Attributes
                         | NotifyFilters.CreationTime
                         | NotifyFilters.DirectoryName
                         | NotifyFilters.FileName
                         | NotifyFilters.LastAccess
                         | NotifyFilters.LastWrite
                         | NotifyFilters.Security
                         | NotifyFilters.Size;

    watcher.Changed += OnChanged;
    watcher.Created += OnCreated;

    watcher.Filter = "*.dat";
    watcher.IncludeSubdirectories = true;
    watcher.EnableRaisingEvents = true;

    Console.WriteLine("Press enter to exit.");
    Console.ReadLine();
}
void OnCreated(object sender, FileSystemEventArgs e)
{
    string value = $"Created: {e.FullPath}";
    Console.WriteLine(value);
}
void OnChanged(object sender, FileSystemEventArgs e)
{
    string value = $"Created: {e.FullPath}";
    Console.WriteLine(value);
}
    
