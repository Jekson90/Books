using Models;

namespace Mappers
{
    public static class LanguageMapper
    {
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

        public static string GetLanguageName(Language language) => language.ToString().ToLower();
    }
}
