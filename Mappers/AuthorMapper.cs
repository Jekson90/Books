using Entities;
using Models;

namespace Mappers
{
    public static class AuthorMapper
    {
        public static AuthorModel GetAuthorModel(this AuthorEntity authorEntity)
        {
            return new AuthorModel()
            {
                Name = authorEntity.Name,
                Language = LanguageMapper.GetLanguage(authorEntity.Language)
            };
        }

        public static AuthorEntity GetAuthorEntity(this AuthorModel authorModel)
        {
            return new AuthorEntity()
            {
                Name = authorModel.Name,
                Language = LanguageMapper.GetLanguageName(authorModel.Language)
            };
        }
    }
}
