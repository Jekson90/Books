namespace Books.CustomLogger
{
    /// <summary>
    /// Сущность, которая собирает отформатированные 
    /// строчки из ошибки, включая InnerException
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// отформатированные строки
        /// </summary>
        public List<string> Lines { get; private set; } = new();
        /// <summary>
        /// счетчик рекурсии по внутренним исключениям
        /// </summary>
        private int _innerCounter;

        public ErrorMessage(Exception ex)
        {
            _innerCounter = 0;
            SetMessage(ex);
        }

        /// <summary>
        /// создать сообщение по исключению
        /// </summary>
        /// <param name="ex"></param>
        private void SetMessage(Exception ex)
        {
            AddException(ex);
            LogInnerException(ex);
        }

        /// <summary>
        /// информация о текущем исключении
        /// </summary>
        /// <param name="ex"></param>
        private void AddException(Exception ex)
        {
            Add("message", ex.Message);
            Add("stack trace", ex.StackTrace ?? "");
            Add("source", ex.Source ?? "");
            Add("target site", ex.TargetSite?.ToString() ?? "");
        }

        /// <summary>
        /// добавить строчку
        /// </summary>
        /// <param name="name">название строчки</param>
        /// <param name="msg">сожержание сообщения</param>
        private void Add(string name, string msg)
        {
            string tabulation = string.Empty;
            for (int i = 0; i < _innerCounter; i++)
                tabulation += "\t\t";
            string line = $"{tabulation}{name} = {msg}";
            Lines.Add(line);
        }

        /// <summary>
        /// информация о внутреннем исключении
        /// </summary>
        /// <param name="ex"></param>
        public void LogInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                _innerCounter++;
                var ex1 = ex.InnerException;
                Add($"inner{_innerCounter}", ">");
                SetMessage(ex1);
                _innerCounter--;
            }
        }
    }
}
