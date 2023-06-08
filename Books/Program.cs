using Books.CustomLogger;
using CrudService;
using Interfaces;

//минимальные настройки хоста
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllers();
//инжектируем наш сервис
builder.Services.AddTransient<IBookService, BookService>();

//добавляем кастомный логер записи в файл
//но лучше, конечно, использовать коробочное решение
var logFileName = builder.Configuration["LogPath"];
builder.Logging.AddFile(logFileName);

var app = builder.Build();
//прошу не судить строго по фронту, это не совсем моё)
app.MapControllerRoute("/", "{controller=Main}/{action=Index}");
app.Run();
