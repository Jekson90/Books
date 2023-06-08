using Books.DTO;
using Interfaces;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models.Search;

namespace Books.Controllers
{
    public class BookController : ControllerLoggerBase
    {
        private IBookService _bookService;
        private IConfiguration _config;

        public BookController(IBookService bookService, IConfiguration config, ILogger<BookController> logger) : base(logger)
        {
            _bookService = bookService;
            _config = config;
        }

        /// <summary>
        /// Запрос на получение списка книг в соответствии с параметрами (параметры не обязательны)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="category"></param>
        /// <param name="author"></param>
        /// <param name="count"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [ActionName("search")]
        public IActionResult GetBooks(string title = "", string category = "", string author = "", int count = 5, int pageNumber = 0)
        {
            LogRequest(Request);

            try
            {
                if (count == 0)
                    count++;
                if (pageNumber <= 0)
                    pageNumber = 1;

                SetJson();

                //рекомендуется передавать параметры в одном объекте, если их больше 3х шт
                var parameters = new SearchParameters()
                {
                    Title = title,
                    Category = category,
                    Author = author,
                    PagesCount = count,
                    PageNumber = pageNumber
                };
                var books = _bookService.GetBooks(parameters);
                //перекладываем результат в DTO-шки, для дальнейшей сериализации
                var booksDto = new List<BookDescription>();

                foreach (var book in books)
                {
                    booksDto.Add(new BookDescription
                    {
                        Title = book.Title,
                        Category = book.Category,
                        PublishDate = book.PublishDate,
                        Language = LanguageMapper.GetLanguageName(book.Language),
                        PagesCount = book.PagesCount,
                        AgeLimit = book.AgeLimit,
                        Authors = new List<AuthorDescription>(book.Authors.Select(x => new AuthorDescription()
                        {
                            Name = x.Name,
                            Language = LanguageMapper.GetLanguageName(x.Language)
                        }))
                    });
                }

                Log($"Return books: count={booksDto.Count}, page={pageNumber}");
                return Ok(booksDto);
            }
            catch (Exception ex)
            {
                //в случае ошибок - логируем и сообщаем на фронт
                LogError(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Запрос на получение списка категорий
        /// </summary>
        /// <returns></returns>
        [ActionName("category")]
        public IActionResult GetCategories()
        {
            LogRequest(Request);
            List<string> categories = new();

            try
            {
                SetJson();
                categories.AddRange(_bookService.GetCategories());
            }
            catch (Exception ex)
            {
                LogError(ex);
                categories.Add("Все");
            }

            Log($"Return categories list: count={categories.Count}");
            return Ok(categories);
        }

        /// <summary>
        /// Тестовый запрос, на логирование ошибок
        /// https://localhost:7287/book/error
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IActionResult Error()
        {
            Log("Test error log");

            try
            {
                var inner = new IndexOutOfRangeException("Test inner exception");
                throw new ArgumentException("Test exception", inner);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return new StatusCodeResult(500);
        }

        /// <summary>
        /// Настройка источника данных
        /// </summary>
        private void SetJson()
        {
            var path = _config["FilePath"];
            _bookService.SetJsonReader(path);
        }
    }
}
