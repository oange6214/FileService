namespace FileService.FileParsers;

using FileService.FileParsers.XMLMapping;
using System.IO;
using System.Xml.Serialization;

public class XmlFileParserBySerialization : IFileParser
{
    public void Parse(string filePath)
    {
        XmlSerializer serializer = new(typeof(Bookstore));

        using StreamReader reader = new StreamReader(filePath);
        Bookstore bookstore = (Bookstore)serializer.Deserialize(reader);

        foreach (var book in bookstore.Books)
        {
            Console.WriteLine($"Category: {book.Category}, Title: {book.Title.Text}, Author: {book.Author}, Year: {book.Year}, Price: {book.Price}");
        }
    }
}

