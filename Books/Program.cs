using Books.CustomLogger;
using CrudService;
using Interfaces;

//����������� ��������� �����
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllers();
//����������� ��� ������
builder.Services.AddTransient<IBookService, BookService>();

//��������� ��������� ����� ������ � ����
//�� �����, �������, ������������ ���������� �������
var logFileName = builder.Configuration["LogPath"];
builder.Logging.AddFile(logFileName);

var app = builder.Build();
//����� �� ������ ������ �� ������, ��� �� ������ ��)
app.MapControllerRoute("/", "{controller=Main}/{action=Index}");
app.Run();
