using FileReader;
using Models;
using Mappers;
using Interfaces;
using Models.Search;

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
            if (_jsonReader == null)
                throw new IOException("JsonReader didn't set");

            var booksEntity = _jsonReader.GetAllBooks();
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
            var categories = new List<string> { "Все" };
            categories.AddRange(_jsonReader.GetAllBooks().GroupBy(x => x.Category).Select(x => x.Key));
            return categories;
        }
    }
}