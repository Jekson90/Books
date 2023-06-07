namespace Models.Search
{
    public class SearchParameters
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public int PagesCount { get; set; }
        public int PageNumber { get; set; }
    }
}
