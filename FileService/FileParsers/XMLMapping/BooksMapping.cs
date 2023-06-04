namespace FileService.FileParsers.XMLMapping;

using System.Collections.Generic;
using System.Xml.Serialization;

public class Title
{
    [XmlAttribute("lang")]
    public string Language { get; set; }
    [XmlText]
    public string Text { get; set; }
}

public class Book
{
    [XmlAttribute("category")]
    public string Category { get; set; }

    [XmlElement("title")]
    public Title Title { get; set; }

    [XmlElement("author")]
    public string Author { get; set; }

    [XmlElement("year")]
    public int Year { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}

[XmlRoot("bookstore")]
public class Bookstore
{
    [XmlElement("book")]
    public List<Book> Books { get; set; }
}