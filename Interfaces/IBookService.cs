using Models;
using Models.Search;

namespace Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Возвращает список книг в соответствии с параметрами
        /// </summary>
        /// <param name="parameters">Параметры</param>
        /// <returns></returns>
        List<BookModel> GetBooks(SearchParameters parameters);
        /// <summary>
        /// Возвращает список доступных категорий
        /// </summary>
        /// <returns></returns>
        List<string> GetCategories();
        /// <summary>
        /// Настройка ридера источника данных
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        void SetJsonReader(string path);
    }
}