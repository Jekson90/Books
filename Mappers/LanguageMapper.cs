using Models;

namespace Mappers
{
    public static class LanguageMapper
    {
        /// <summary>
        /// String to Enumeration
        /// </summary>
        /// <param name="languageStr"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Language GetLanguage(string languageStr)
        {
            languageStr = languageStr.ToLower();
            foreach (var name in Enum.GetNames(typeof(Language)))
            {
                var enumName = name.ToLower();
                if (enumName == languageStr)
                    return (Language)Enum.Parse(typeof(Language), name);
            }

            throw new ArgumentException("Wrong language type.");
        }

        /// <summary>
        /// Enumeration to String
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string GetLanguageName(Language language) => language.ToString().ToLower();
    }
}
