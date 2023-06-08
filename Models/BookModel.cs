namespace Models
{
    /// <summary>
    /// Книга (бизнес-слой)
    /// </summary>
    public class BookModel
    {
        public string Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        public int PublishDate { get; set; }
        /// <summary>
        /// Язык, на котором написана книга
        /// </summary>
        public Language Language { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PagesCount { get; set; }
        /// <summary>
        /// Ограничение по возрасту
        /// </summary>
        public int AgeLimit { get; set; }
        /// <summary>
        /// Авторы
        /// </summary>
        public List<AuthorModel> Authors { get; set; }
    }
}