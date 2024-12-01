using BookDemo.Models;
namespace BookDemo;

public static class ApplicationDbContext
{
    public static List<Book> Books { get; set; }
    static ApplicationDbContext()
    {
        Books = new List<Book>()
        {
            new Book {Id=1,Title="Karagöz ve Hacivat",Price=500},
            new Book {Id=2,Title="Suc ve Ceza",Price=400 },
            new Book {Id=3,Title="Atatürk ve Cumhuriyet",Price=620 }
    };
    }
}