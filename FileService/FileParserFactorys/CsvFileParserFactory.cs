using FileService.FileParsers;

namespace FileService.FileParserFactorys;
internal class CsvFileParserFactory : FileParserFactory
{
    public override IFileParser CreateFileParser()
    {
        return new CsvFileParserByCsvHelper();
    }
}