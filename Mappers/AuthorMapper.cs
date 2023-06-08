using Entities;
using Models;

namespace Mappers
{
    public static class AuthorMapper
    {
        /// <summary>
        /// Entity to Model
        /// </summary>
        /// <param name="authorEntity"></param>
        /// <returns></returns>
        public static AuthorModel GetAuthorModel(this AuthorEntity authorEntity)
        {
            return new AuthorModel()
            {
                Name = authorEntity.Name,
                Language = LanguageMapper.GetLanguage(authorEntity.Language)
            };
        }

        /// <summary>
        /// Model to Entity
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
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
