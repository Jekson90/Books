using Models;
using Mappers;
using Interfaces;
using Models.Search;
using FileReader.Json;

namespace CrudService
{
    /// <summary>
    /// Сервис для извления книг по запросу
    /// </summary>
    public class BookService : IBookService
    {
        private JsonReader? _jsonReader;

        public void SetJsonReader(string path)
        {
            string jsonBooksPath = Directory.GetCurrentDirectory();
            jsonBooksPath = Path.Combine(jsonBooksPath, path);
            _jsonReader = new JsonReader(jsonBooksPath);
        }

        public List<BookModel> GetBooks(SearchParameters parameters)
        {
            CheckJson();

            var booksEntity = _jsonReader!.GetAllBooks();
            if (booksEntity == null)
                throw new FileLoadException("Can't read JSON file");

            return booksEntity.Where(x => x.Title.ToLower().Contains(parameters.Title.ToLower()) || string.IsNullOrEmpty(parameters.Title))
                              .Where(x => x.Category.Replace(" ","") == parameters.Category || parameters.Category == "Все")
                              .Where(x => x.Authors.Any(x => x.Name.ToLower().Contains(parameters.Author.ToLower())) || string.IsNullOrEmpty(parameters.Author))
                              .Skip((parameters.PageNumber - 1) * parameters.PagesCount)
                              .Take(parameters.PagesCount)
                              .Select(x => x.GetBookModel())
                              .ToList();
        }

        public List<string> GetCategories()
        {
            CheckJson();
            
            var categories = new List<string> { "Все" };
            var books = _jsonReader!.GetAllBooks();

            if (books != null)
                categories.AddRange(books.GroupBy(x => x.Category).Select(x => x.Key));

            return categories;
        }

        private void CheckJson()
        {
            if (_jsonReader == null)
                throw new IOException("JsonReader didn't set");
        }
    }
}