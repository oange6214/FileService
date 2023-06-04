using FileService.FileParsers;

namespace FileService.FileParserFactorys;

internal class JsonFileParserFactory : FileParserFactory
{
    public override IFileParser CreateFileParser()
    {
        return new JsonFileParser();
    }
}
