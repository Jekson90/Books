namespace Books.DTO
{
    public class BookDescription
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public int PublishDate { get; set; }
        public string Language { get; set; }
        public int PagesCount { get; set; }
        public int AgeLimit { get; set; }
        public List<AuthorDescription> Authors { get; set; }
    }
}
