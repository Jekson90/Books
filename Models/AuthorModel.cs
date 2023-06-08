namespace Models
{
    public class AuthorModel
    {
        /// <summary>
        /// Имя автора
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Страна рождения автора
        /// </summary>
        public Language Language { get; set; }
    }
}
