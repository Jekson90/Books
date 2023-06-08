namespace FileReader.Json
{
    /// <summary>
    /// Книга для десереализации
    /// </summary>
    internal class BookJsonModel
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? category { get; set; }
        public string? publicationDate { get; set; }
        public string? lang { get; set; }
        public int? pages { get; set; }
        public int? ageLimit { get; set; }
        public List<AuthorJsonModel>? authors { get; set; }
    }
}
