using System.Text;

namespace Books.CustomLogger
{
    public class FileLogger : ILogger, IDisposable
    {
        private const string Splitter = " | ";
        private static object _lock = new object();
        private string _filePath;

        public FileLogger(string path)
        {
            _filePath = path;
        }

        // конструктор строки лога и запись в файл
        public void Log<TState>(LogLevel logLevel,
                                EventId eventId,
                                TState state,
                                Exception? exception,
                                Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                var isException = exception != null;
                var line = new StringBuilder()
                              .Append(DateTime.Now)
                              .Append(Splitter)
                              .Append(logLevel)
                              .Append(Splitter)
                              .Append($"Thread#{Thread.CurrentThread.ManagedThreadId}")
                              .Append(Splitter)
                              .Append($"IsException={isException}")
                              .Append(Splitter);

                if (isException)
                {
                    line.AppendLine(exception!.Message);
                    var error = new ErrorMessage(exception);
                    foreach (var l in error.Lines)
                        line.AppendLine(l);
                }
                else
                    line.Append(state?.ToString() ?? "none");

                //не самое лучшее решение логировать в вызывающем потоке, но времени больше не осталось
                File.AppendAllText(_filePath, line.ToString() + Environment.NewLine);
            }
        }

        public bool IsEnabled(LogLevel level) => true;
        public IDisposable BeginScope<TState>(TState state) => this;
        public void Dispose() { }
    }
}
