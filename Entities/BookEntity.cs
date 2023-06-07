namespace Entities
{
    public class BookEntity
    {
        public string Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Категория книги
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Дата публикации книги
        /// </summary>
        public int PublishDate { get; set; }
        /// <summary>
        /// Язык, на котором написана книга
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PagesCount { get; set; }
        /// <summary>
        /// Ограничение по возрасту
        /// </summary>
        public int AgeLimit { get; set; }
        /// <summary>
        /// Список авторов
        /// </summary>
        public List<AuthorEntity> Authors { get; set; }
    }
}
