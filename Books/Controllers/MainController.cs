using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    public class MainController : ControllerLoggerBase
    {
        public MainController(ILogger<MainController> logger) : base(logger) { }

        /// <summary>
        /// Стартовая страница
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            Log("Get main page");
            LogRequest(Request);
            return View();
        }
    }
}
