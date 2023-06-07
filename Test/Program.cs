// See https://aka.ms/new-console-template for more information
using FileReader;

Console.WriteLine("Hello, World!");

string path = Directory.GetCurrentDirectory();
path = Path.Combine(path, "books.json");
var reader = new JsonReader(path);
var books = reader.GetAllBooks();

Console.ReadKey();