namespace Books.CustomLogger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string _path;
        public FileLoggerProvider(string path) => _path = path;
        public ILogger CreateLogger(string categoryName) => new FileLogger(_path);
        public void Dispose() { }
    }
}
