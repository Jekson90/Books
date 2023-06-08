using System.Reflection;

namespace Books.CustomLogger
{
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Метод расширения, для добавления провайдера логера
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string fileName)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            path = Path.Combine(path, "Log");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, fileName);
            builder.AddProvider(new FileLoggerProvider(path));
            return builder;
        }
    }
}
