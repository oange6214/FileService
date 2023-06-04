namespace FileService.FileParsers.JsonMapping;

public class Root
{
    public Bookstore Bookstore { get; set; }
}

public class Bookstore
{
    public List<Book> Book { get; set; }
}

public class Book
{
    public string Category { get; set; }
    public Title Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
}

public class Title
{
    public string Lang { get; set; }
    public string Text { get; set; }
}
