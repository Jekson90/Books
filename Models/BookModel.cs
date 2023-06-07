namespace Models
{
    /// <summary>
    /// Объекты бизнес-слоя
    /// </summary>
    public class BookModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int PublishDate { get; set; }
        public Language Language { get; set; }
        public int PagesCount { get; set; }
        public int AgeLimit { get; set; }
        public List<AuthorModel> Authors { get; set; }
    }
}