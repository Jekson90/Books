namespace Models.Search
{
    public class SearchParameters
    {
        /// <summary>
        /// Строка поиска книги по названию
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Категория из списка доступных для поиска
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Строка поиска книги по автору
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Количество книг для отображения на одной странице
        /// </summary>
        public int PagesCount { get; set; }
        /// <summary>
        /// Номер запрашиваемой страницы для отображения
        /// </summary>
        public int PageNumber { get; set; }
    }
}
