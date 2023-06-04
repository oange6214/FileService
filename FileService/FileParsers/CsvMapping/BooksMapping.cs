using System.ComponentModel.DataAnnotations;

namespace FileService.FileParsers.CsvMapping;
public class Book
{
    [Display(Name = "類別")]
    public string Category { get; set; }
    [Display(Name = "書名")]
    public string Title { get; set; }
    [Display(Name = "作者")]
    public string Author { get; set; }
    [Display(Name = "出版日")]
    public int Year { get; set; }
    [Display(Name = "價格")]
    public decimal Price { get; set; }
}
