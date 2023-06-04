
using CsvHelper;
using CsvHelper.Configuration;
using FileService.FileParsers.CsvMapping;
using System.Globalization;

namespace FileService.FileParsers;

public class CsvFileParserByCsvHelper : IFileParser
{
    public void Parse(string filePath)
    {
        try
        {
            using StreamReader reader = new(filePath);
            CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
            };

            using CsvReader csvReader = new(reader, csvConfig);
            IEnumerable<Book> books = csvReader.GetRecords<Book>();

            foreach (Book book in books)
            {
                Console.WriteLine($"Category: {book.Category}\tTitle: {book.Title}\tAuthor: {book.Author}\tYear: {book.Year}\tPrice: {book.Price}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while parsing the CSV file: " + ex.Message);
        }
    }
}
