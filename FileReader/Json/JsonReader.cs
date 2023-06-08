using Entities;
using System.Text.Json;

namespace FileReader.Json
{
    public class JsonReader
    {
        private static readonly object _locker = new();
        private string _filePath;
        public JsonReader(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Прочитать из файла
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public List<BookEntity>? GetAllBooks()
        {
            if (string.IsNullOrEmpty(_filePath))
                throw new ArgumentException("File path might not be empty.");

            if (!File.Exists(_filePath))
                throw new ArgumentException($"Path {_filePath} does not exist.");

            string jsonString;
            lock (_locker)
                jsonString = File.ReadAllText(_filePath);

            var books = JsonSerializer.Deserialize<List<BookJsonModel>>(jsonString);
            return books?.Select(x => x.GetBookEntity()).ToList();
        }
    }
}