using FileService.FileParserFactorys;
using FileService.FileParsers;

FileParserFactory factory = new CsvFileParserFactory();
IFileParser parser = factory.CreateFileParser();
parser.Parse("TextFiles/Books.csv");

