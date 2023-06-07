using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    /// <summary>
    /// Базовый контроллер для описания логирования
    /// </summary>
    public abstract class ControllerLoggerBase : Controller
    {
        protected ILogger _logger;

        public ControllerLoggerBase(ILogger logger)
        {
            _logger = logger;
        }

        //обернем логи для удобства
        //удобно вынести их в базовый класс, для всех подобных контроллеров, что бы не дублировать код
        protected void Log(string message) => _logger.LogInformation(message);
        protected void LogRequest(HttpRequest request) => _logger.LogInformation($"Request-{request.Path}");
        protected void LogError(Exception ex) => _logger.LogError(ex, "");
    }
}
