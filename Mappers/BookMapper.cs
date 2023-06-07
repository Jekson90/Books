using Entities;
using Models;

namespace Mappers
{
    public static class BookMapper
    {
        public static BookEntity GetBookEntity(this BookModel bookModel)
        {
            return new BookEntity()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Category = bookModel.Category,
                PublishDate = bookModel.PublishDate,
                Language = LanguageMapper.GetLanguageName(bookModel.Language),
                PagesCount = bookModel.PagesCount,
                AgeLimit = bookModel.AgeLimit,
                Authors = new List<AuthorEntity>(bookModel.Authors.Select(x => x.GetAuthorEntity()))
            };
        }

        public static BookModel GetBookModel(this BookEntity bookEntity)
        {
            return new BookModel()
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Category = bookEntity.Category,
                PublishDate = bookEntity.PublishDate,
                Language = LanguageMapper.GetLanguage(bookEntity.Language),
                PagesCount = bookEntity.PagesCount,
                AgeLimit = bookEntity.AgeLimit,
                Authors = new List<AuthorModel>(bookEntity.Authors.Select(x => x.GetAuthorModel()))
            };
        }
    }
}