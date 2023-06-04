using FileService.FileParsers.CsvMapping;
using System.Text;

namespace FileService.FileParsers;

public class CsvFileParser : IFileParser
{
    public void Parse(string filePath)
    {
        try
        {
            List<Book> data = new List<Book>();

            using (StreamReader reader = new(filePath))
            {
                string headerLine = reader.ReadLine(); // 讀取標題行
                string[] headers = headerLine.Split(',');

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] row = line.Split(',');

                    if (row.Length == headers.Length)
                    {
                        Book book = new();

                        for (int i = 0; i < headers.Length; i++)
                        {
                            string header = headers[i];
                            string value = row[i];

                            switch (header)
                            {
                                case "category":
                                    book.Category = value;
                                    break;
                                case "title":
                                    book.Title = value;
                                    break;
                                case "author":
                                    book.Author = value;
                                    break;
                                case "year":
                                    book.Year = int.Parse(value);
                                    break;
                                case "price":
                                    book.Price = decimal.Parse(value);
                                    break;
                            }
                        }

                        data.Add(book);
                    }
                    else
                    {
                        Console.WriteLine("Invalid CSV data: " + line);
                    }
                }
            }

            if (data.Count > 0)
            {
                // 在這裡可以對解析後的資料進行後續處理
                // ...

                // 範例：將解析後的資料印出來
                StringBuilder output = new();
                foreach (Book book in data)
                {
                    output.AppendLine($"Category: {book.Category}\tTitle: {book.Title}\tAuthor: {book.Author}\tYear: {book.Year}\tPrice: {book.Price}");
                }

                Console.WriteLine(output.ToString());
            }
            else
            {
                Console.WriteLine("CSV file is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while parsing the CSV file: " + ex.Message);
        }
    }
}
