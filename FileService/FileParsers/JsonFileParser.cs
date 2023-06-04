using FileService.FileParsers.JsonMapping;
using Newtonsoft.Json;

namespace FileService.FileParsers;

public class JsonFileParser : IFileParser
{
    public void Parse(string filePath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            // Read the file content
            string fileContent = File.ReadAllText(filePath);

            // Deserialize JSON
            var json = JsonConvert.DeserializeObject<Root>(fileContent);
            var books = json?.Bookstore?.Book;

            // Do something with the deserialized JSON
            if (books != null)
            {
                Console.WriteLine("The parsed books are: ");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title.Text} by {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("No books found in the JSON data.");
            }
        }
        catch (JsonReaderException jre)
        {
            Console.WriteLine("An error occurred while parsing the JSON: ");
            Console.WriteLine(jre.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: ");
            Console.WriteLine(e.Message);
        }
    }
}
