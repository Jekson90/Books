using Entities;

namespace FileReader.Json
{
    /// <summary>
    /// Мапер на сущности
    /// </summary>
    internal static class EntityMapper
    {
        public static BookEntity GetBookEntity(this BookJsonModel jBook)
        {
            int.TryParse(jBook.publicationDate, out int publishDate);

            return new BookEntity()
            {
                Id = jBook.id ?? string.Empty,
                Title = jBook.title ?? string.Empty,
                Category = jBook.category ?? string.Empty,
                PublishDate = publishDate,
                Language = jBook.lang ?? string.Empty,
                PagesCount = jBook.pages ?? 0,
                AgeLimit = jBook.ageLimit ?? 0,
                Authors = new List<AuthorEntity>(jBook.authors?.Select(x => x.GetAuthorEntity())!)
            };

        }

        public static AuthorEntity GetAuthorEntity(this AuthorJsonModel jAuthor)
        {
            return new AuthorEntity()
            {
                Name = jAuthor.name ?? string.Empty,
                Language = jAuthor.lang ?? string.Empty
            };
        }
    }
}
